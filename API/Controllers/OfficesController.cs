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
    public class OfficesController : ApiController
    {
        private session1Entities db = new session1Entities();

        // GET: api/Offices
        public IQueryable<Offices> GetOffices()
        {
            return db.Offices;
        }

        // GET: api/Offices/5
        [ResponseType(typeof(Offices))]
        public async Task<IHttpActionResult> GetOffices(int id)
        {
            Offices offices = await db.Offices.FindAsync(id);
            if (offices == null)
            {
                return NotFound();
            }

            return Ok(offices);
        }

        // PUT: api/Offices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOffices(int id, Offices offices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != offices.ID)
            {
                return BadRequest();
            }

            db.Entry(offices).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficesExists(id))
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

        // POST: api/Offices
        [ResponseType(typeof(Offices))]
        public async Task<IHttpActionResult> PostOffices(Offices offices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Offices.Add(offices);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = offices.ID }, offices);
        }

        // DELETE: api/Offices/5
        [ResponseType(typeof(Offices))]
        public async Task<IHttpActionResult> DeleteOffices(int id)
        {
            Offices offices = await db.Offices.FindAsync(id);
            if (offices == null)
            {
                return NotFound();
            }

            db.Offices.Remove(offices);
            await db.SaveChangesAsync();

            return Ok(offices);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OfficesExists(int id)
        {
            return db.Offices.Count(e => e.ID == id) > 0;
        }
    }
}