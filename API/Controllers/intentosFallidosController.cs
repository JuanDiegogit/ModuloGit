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
    public class intentosFallidosController : ApiController
    {
        private session1Entities db = new session1Entities();

        // GET: api/intentosFallidos
        public IQueryable<intentosFallido> GetintentosFallido()
        {
            return db.intentosFallido;
        }

        // GET: api/intentosFallidos/5
        [ResponseType(typeof(intentosFallido))]
        public async Task<IHttpActionResult> GetintentosFallido(int id)
        {
            intentosFallido intentosFallido = await db.intentosFallido.FindAsync(id);
            if (intentosFallido == null)
            {
                return NotFound();
            }

            return Ok(intentosFallido);
        }

        // PUT: api/intentosFallidos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutintentosFallido(int id, intentosFallido intentosFallido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != intentosFallido.ID)
            {
                return BadRequest();
            }

            db.Entry(intentosFallido).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!intentosFallidoExists(id))
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

        // POST: api/intentosFallidos
        [ResponseType(typeof(intentosFallido))]
        public async Task<IHttpActionResult> PostintentosFallido(intentosFallido intentosFallido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.intentosFallido.Add(intentosFallido);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = intentosFallido.ID }, intentosFallido);
        }

        // DELETE: api/intentosFallidos/5
        [ResponseType(typeof(intentosFallido))]
        public async Task<IHttpActionResult> DeleteintentosFallido(int id)
        {
            intentosFallido intentosFallido = await db.intentosFallido.FindAsync(id);
            if (intentosFallido == null)
            {
                return NotFound();
            }

            db.intentosFallido.Remove(intentosFallido);
            await db.SaveChangesAsync();

            return Ok(intentosFallido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool intentosFallidoExists(int id)
        {
            return db.intentosFallido.Count(e => e.ID == id) > 0;
        }
    }
}