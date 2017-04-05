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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using datamodel;

namespace adnet.test.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using datamodel;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<AdvertisingCompany>("AdvertisingCompanies");
    builder.EntitySet<Advertiser>("Advertisers"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class AdvertisingCompaniesController : ODataController
    {
        private AdDbContext db = new AdDbContext();

        // GET: odata/AdvertisingCompanies
        [EnableQuery]
        public IQueryable<AdvertisingCompany> GetAdvertisingCompanies()
        {
            return db.AdvertisingCompanies;
        }

        // GET: odata/AdvertisingCompanies(5)
        [EnableQuery]
        public SingleResult<AdvertisingCompany> GetAdvertisingCompany([FromODataUri] int key)
        {
            return SingleResult.Create(db.AdvertisingCompanies.Where(advertisingCompany => advertisingCompany.Id == key));
        }

        // PUT: odata/AdvertisingCompanies(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<AdvertisingCompany> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AdvertisingCompany advertisingCompany = await db.AdvertisingCompanies.FindAsync(key);
            if (advertisingCompany == null)
            {
                return NotFound();
            }

            patch.Put(advertisingCompany);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertisingCompanyExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(advertisingCompany);
        }

        // POST: odata/AdvertisingCompanies
        public async Task<IHttpActionResult> Post(AdvertisingCompany advertisingCompany)
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

            return Created(advertisingCompany);
        }

        // PATCH: odata/AdvertisingCompanies(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<AdvertisingCompany> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AdvertisingCompany advertisingCompany = await db.AdvertisingCompanies.FindAsync(key);
            if (advertisingCompany == null)
            {
                return NotFound();
            }

            patch.Patch(advertisingCompany);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertisingCompanyExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(advertisingCompany);
        }

        // DELETE: odata/AdvertisingCompanies(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            AdvertisingCompany advertisingCompany = await db.AdvertisingCompanies.FindAsync(key);
            if (advertisingCompany == null)
            {
                return NotFound();
            }

            db.AdvertisingCompanies.Remove(advertisingCompany);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/AdvertisingCompanies(5)/Advertiser
        [EnableQuery]
        public SingleResult<Advertiser> GetAdvertiser([FromODataUri] int key)
        {
            return SingleResult.Create(db.AdvertisingCompanies.Where(m => m.Id == key).Select(m => m.Advertiser));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdvertisingCompanyExists(int key)
        {
            return db.AdvertisingCompanies.Count(e => e.Id == key) > 0;
        }
    }
}
