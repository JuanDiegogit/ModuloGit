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
using API.Models;

namespace API.Controllers
{
    public class CountriesController : ApiController
    {
        private session1Entities db = new session1Entities();

        // GET: api/Countries
        public IQueryable<Countries> GetCountries()
        {
            return db.Countries;
        }

        // GET: api/Countries/5
        [ResponseType(typeof(Countries))]
        public async Task<IHttpActionResult> GetCountries(int id)
        {
            Countries countries = await db.Countries.FindAsync(id);
            if (countries == null)
            {
                return NotFound();
            }

            return Ok(countries);
        }

        // PUT: api/Countries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCountries(int id, Countries countries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != countries.ID)
            {
                return BadRequest();
            }

            db.Entry(countries).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountriesExists(id))
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

        // POST: api/Countries
        [ResponseType(typeof(Countries))]
        public async Task<IHttpActionResult> PostCountries(Countries countries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Countries.Add(countries);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = countries.ID }, countries);
        }

        // DELETE: api/Countries/5
        [ResponseType(typeof(Countries))]
        public async Task<IHttpActionResult> DeleteCountries(int id)
        {
            Countries countries = await db.Countries.FindAsync(id);
            if (countries == null)
            {
                return NotFound();
            }

            db.Countries.Remove(countries);
            await db.SaveChangesAsync();

            return Ok(countries);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountriesExists(int id)
        {
            return db.Countries.Count(e => e.ID == id) > 0;
        }
    }
}