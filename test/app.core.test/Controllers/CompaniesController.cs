using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;

namespace app.core.test.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly adsdbContext _context;

        public CompaniesController(adsdbContext context)
        {
            _context = context;    
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            var adsdbContext = _context.AdvertisingCompany.Include(a => a.CreatedByNavigation);
            return View(await adsdbContext.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisingCompany = await _context.AdvertisingCompany
                .Include(a => a.CreatedByNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (advertisingCompany == null)
            {
                return NotFound();
            }

            return View(advertisingCompany);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            ViewData["CreatedBy"] = new SelectList(_context.Advertiser, "Id", "Name");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreationDate,IsActive,CreatedBy")] AdvertisingCompany advertisingCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advertisingCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CreatedBy"] = new SelectList(_context.Advertiser, "Id", "Name", advertisingCompany.CreatedBy);
            return View(advertisingCompany);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisingCompany = await _context.AdvertisingCompany.SingleOrDefaultAsync(m => m.Id == id);
            if (advertisingCompany == null)
            {
                return NotFound();
            }
            ViewData["CreatedBy"] = new SelectList(_context.Advertiser, "Id", "Name", advertisingCompany.CreatedBy);
            return View(advertisingCompany);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreationDate,IsActive,CreatedBy")] AdvertisingCompany advertisingCompany)
        {
            if (id != advertisingCompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advertisingCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertisingCompanyExists(advertisingCompany.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["CreatedBy"] = new SelectList(_context.Advertiser, "Id", "Name", advertisingCompany.CreatedBy);
            return View(advertisingCompany);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisingCompany = await _context.AdvertisingCompany
                .Include(a => a.CreatedByNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (advertisingCompany == null)
            {
                return NotFound();
            }

            return View(advertisingCompany);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advertisingCompany = await _context.AdvertisingCompany.SingleOrDefaultAsync(m => m.Id == id);
            _context.AdvertisingCompany.Remove(advertisingCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AdvertisingCompanyExists(int id)
        {
            return _context.AdvertisingCompany.Any(e => e.Id == id);
        }
    }
}
