using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulacro.Data;
using Simulacro.Models;

namespace Simulacro.Controllers
{
public class SectorsController : Controller
    {
        public readonly  BaseContext _context;

        public SectorsController(BaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string Search)
        {
            var s = from sectors in _context.Sectors select sectors;
            if (!string.IsNullOrEmpty(Search))
            {
                s = s.Where(c => c.Name.Contains(Search) || c.Author.Contains(Search));
            }
            return View(await s.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            return View(await _context.Sectors.FindAsync(id));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSectors(Sectors s)
        {
            _context.Sectors.Add(s);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            return View(await _context.Sectors.FindAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditSector(Sectors s)
        {
            _context.Sectors.Update(s);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            return View (await _context.Sectors.FindAsync(id));
        }

        public async Task<IActionResult> DeleteSector(int id)
        {
            var sector= await _context.Sectors.FindAsync(id);
            _context.Sectors.Remove(sector);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}