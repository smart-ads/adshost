using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using datamodel;

namespace WebApp.test.Controllers
{
    public class AdvertisingCompaniesController : ApiController
    {
        private AdDbContext db = new AdDbContext();

        // GET: api/AdvertisingCompanies
        public IQueryable<AdvertisingCompany> GetAdvertisingCompanies()
        {
            return db.AdvertisingCompanies;
        }

        // GET: api/AdvertisingCompanies/5
        [ResponseType(typeof(AdvertisingCompany))]
        public async Task<IHttpActionResult> GetAdvertisingCompany(int id)
        {
            AdvertisingCompany advertisingCompany = await db.AdvertisingCompanies.FindAsync(id);
            if (advertisingCompany == null)
            {
                return NotFound();
            }

            return Ok(advertisingCompany);
        }

        // PUT: api/AdvertisingCompanies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdvertisingCompany(int id, AdvertisingCompany advertisingCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != advertisingCompany.Id)
            {
                return BadRequest();
            }

            db.Entry(advertisingCompany).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertisingCompanyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AdvertisingCompanies
        [ResponseType(typeof(AdvertisingCompany))]
        public async Task<IHttpActionResult> PostAdvertisingCompany(AdvertisingCompany advertisingCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdvertisingCompanies.Add(advertisingCompany);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdvertisingCompanyExists(advertisingCompany.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = advertisingCompany.Id }, advertisingCompany);
        }

        // DELETE: api/AdvertisingCompanies/5
        [ResponseType(typeof(AdvertisingCompany))]
        public async Task<IHttpActionResult> DeleteAdvertisingCompany(int id)
        {
            AdvertisingCompany advertisingCompany = await db.AdvertisingCompanies.FindAsync(id);
            if (advertisingCompany == null)
            {
                return NotFound();
            }

            db.AdvertisingCompanies.Remove(advertisingCompany);
            await db.SaveChangesAsync();

            return Ok(advertisingCompany);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdvertisingCompanyExists(int id)
        {
            return db.AdvertisingCompanies.Count(e => e.Id == id) > 0;
        }
    }
}