using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulacro.Data;
using Simulacro.Models;

namespace Simulacro.Controllers
{
    public class CompaniesController : Controller
    {
        public readonly BaseContext _context;

        public CompaniesController(BaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string Search)
        {
            var company = from companies in _context.Companies select companies;

            if(!string.IsNullOrEmpty(Search))
            {
               company = company.Where(name => name.Name!.Contains(Search));
            }
            return View(await company.ToListAsync());

        }

        public async Task<IActionResult> Details(int? id)
        {
            return View(await _context.Companies.FirstOrDefaultAsync(c =>c.Id == id));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany(Companies c)
        {
            _context.Companies.Add(c);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            return View(await _context.Companies.FindAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditCompany(Companies c)
        {
            _context.Companies.Update(c);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            return View(await _context.Companies.FindAsync(id));
        }

        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");   
        }
    }

}

