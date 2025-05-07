using NewCatalog.Models;
using NewCatalog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;


namespace NewCatalog.Controllers
{

    [Authorize(Roles = "Admin")]

    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Показати список категорій
        public async Task<IActionResult> Index(int? parentId = null)
        {
            var categories = await _context.Categories
                .Where(c => c.ParentCategoryId == parentId)
                .ToListAsync();

            ViewBag.ParentId = parentId;
            return View(categories);
        }

        // Пошук категорій
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View("Index", await _context.Categories.ToListAsync());
            }

            var categories = await _context.Categories
                .Where(c => c.Name.Contains(query))
                .ToListAsync();

            return View("Index", categories);
        }

        // GET: Category/Create
        public IActionResult Create(int? parentId = null)
        {
            ViewBag.ParentCategories = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.ParentId = parentId;
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { parentId = category.ParentCategoryId });
            }

            ViewBag.ParentCategories = new SelectList(_context.Categories, "Id", "Name", category.ParentCategoryId);
            ViewBag.ParentId = category.ParentCategoryId;
            return View(category);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            ViewBag.ParentCategories = new SelectList(_context.Categories.Where(c => c.Id != id), "Id",
                "Name", category.ParentCategoryId);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { parentId = category.ParentCategoryId });
            }

            ViewBag.ParentCategories = new SelectList(_context.Categories.Where(c => c.Id != id), "Id", "Name",
                category.ParentCategoryId);
            return View(category);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }



}
