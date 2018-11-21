using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PedidoAPIsController : ApiController
    {
        private PedidoContext db = new PedidoContext();

        // GET: api/PedidoAPIs
        public IQueryable<PedidoAPI> GetPedidoAPIs()
        {
            return db.PedidoAPIs;
        }

        // GET: api/PedidoAPIs/5
        [ResponseType(typeof(PedidoAPI))]
        public IHttpActionResult GetPedidoAPI(int id)
        {
            PedidoAPI pedidoAPI = db.PedidoAPIs.Find(id);
            if (pedidoAPI == null)
            {
                return NotFound();
            }

            return Ok(pedidoAPI);
        }

        // PUT: api/PedidoAPIs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPedidoAPI(int id, PedidoAPI pedidoAPI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedidoAPI.idPedido)
            {
                return BadRequest();
            }

            db.Entry(pedidoAPI).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoAPIExists(id))
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

        // POST: api/PedidoAPIs
        [ResponseType(typeof(PedidoAPI))]
        public IHttpActionResult PostPedidoAPI(PedidoAPI pedidoAPI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PedidoAPIs.Add(pedidoAPI);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedidoAPI.idPedido }, pedidoAPI);
        }

        // DELETE: api/PedidoAPIs/5
        [ResponseType(typeof(PedidoAPI))]
        public IHttpActionResult DeletePedidoAPI(int id)
        {
            PedidoAPI pedidoAPI = db.PedidoAPIs.Find(id);
            if (pedidoAPI == null)
            {
                return NotFound();
            }

            db.PedidoAPIs.Remove(pedidoAPI);
            db.SaveChanges();

            return Ok(pedidoAPI);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidoAPIExists(int id)
        {
            return db.PedidoAPIs.Count(e => e.idPedido == id) > 0;
        }
    }
}