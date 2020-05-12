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
    public class UsuarioBloqueadosController : ApiController
    {
        private session1Entities db = new session1Entities();

        // GET: api/UsuarioBloqueados
        public IQueryable<UsuarioBloqueados> GetUsuarioBloqueados()
        {
            return db.UsuarioBloqueados;
        }

        // GET: api/UsuarioBloqueados/5
        [ResponseType(typeof(UsuarioBloqueados))]
        public async Task<IHttpActionResult> GetUsuarioBloqueados(int id)
        {
            UsuarioBloqueados usuarioBloqueados = await db.UsuarioBloqueados.FindAsync(id);
            if (usuarioBloqueados == null)
            {
                return NotFound();
            }

            return Ok(usuarioBloqueados);
        }

        // PUT: api/UsuarioBloqueados/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsuarioBloqueados(int id, UsuarioBloqueados usuarioBloqueados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarioBloqueados.ID)
            {
                return BadRequest();
            }

            db.Entry(usuarioBloqueados).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioBloqueadosExists(id))
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

        // POST: api/UsuarioBloqueados
        [ResponseType(typeof(UsuarioBloqueados))]
        public async Task<IHttpActionResult> PostUsuarioBloqueados(UsuarioBloqueados usuarioBloqueados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UsuarioBloqueados.Add(usuarioBloqueados);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usuarioBloqueados.ID }, usuarioBloqueados);
        }

        // DELETE: api/UsuarioBloqueados/5
        [ResponseType(typeof(UsuarioBloqueados))]
        public async Task<IHttpActionResult> DeleteUsuarioBloqueados(int id)
        {
            UsuarioBloqueados usuarioBloqueados = await db.UsuarioBloqueados.FindAsync(id);
            if (usuarioBloqueados == null)
            {
                return NotFound();
            }

            db.UsuarioBloqueados.Remove(usuarioBloqueados);
            await db.SaveChangesAsync();

            return Ok(usuarioBloqueados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioBloqueadosExists(int id)
        {
            return db.UsuarioBloqueados.Count(e => e.ID == id) > 0;
        }
    }
}