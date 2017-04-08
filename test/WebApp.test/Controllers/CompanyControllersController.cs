using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using datamodel;

namespace WebApp.test.Controllers
{
    public class CompanyControllersController : Controller
    {
        private AdDbContext db = new AdDbContext();

        // GET: CompanyControllers
        public async Task<ActionResult> Index()
        {
            var advertisingCompanies = db.AdvertisingCompanies.Include(a => a.Advertiser);
            return View(await advertisingCompanies.ToListAsync());
        }

        // GET: CompanyControllers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertisingCompany advertisingCompany = await db.AdvertisingCompanies.FindAsync(id);
            if (advertisingCompany == null)
            {
                return HttpNotFound();
            }
            return View(advertisingCompany);
        }

        // GET: CompanyControllers/Create
        public ActionResult Create()
        {
            ViewBag.CreatedBy = new SelectList(db.Advertisers, "Id", "Name");
            return View();
        }

        // POST: CompanyControllers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,CreationDate,IsActive,CreatedBy")] AdvertisingCompany advertisingCompany)
        {
            if (ModelState.IsValid)
            {
                db.AdvertisingCompanies.Add(advertisingCompany);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedBy = new SelectList(db.Advertisers, "Id", "Name", advertisingCompany.CreatedBy);
            return View(advertisingCompany);
        }

        // GET: CompanyControllers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertisingCompany advertisingCompany = await db.AdvertisingCompanies.FindAsync(id);
            if (advertisingCompany == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedBy = new SelectList(db.Advertisers, "Id", "Name", advertisingCompany.CreatedBy);
            return View(advertisingCompany);
        }

        // POST: CompanyControllers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,CreationDate,IsActive,CreatedBy")] AdvertisingCompany advertisingCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertisingCompany).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedBy = new SelectList(db.Advertisers, "Id", "Name", advertisingCompany.CreatedBy);
            return View(advertisingCompany);
        }

        // GET: CompanyControllers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertisingCompany advertisingCompany = await db.AdvertisingCompanies.FindAsync(id);
            if (advertisingCompany == null)
            {
                return HttpNotFound();
            }
            return View(advertisingCompany);
        }

        // POST: CompanyControllers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AdvertisingCompany advertisingCompany = await db.AdvertisingCompanies.FindAsync(id);
            db.AdvertisingCompanies.Remove(advertisingCompany);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
