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
using WebAPIService.Context;
using WebAPIService.Models;

namespace WebAPIService.Controllers
{
    public class StoreController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Store
        public IQueryable<Store> GetStores()
        {
            return db.Stores;
        }

        // GET: api/Store/5
        [ResponseType(typeof(Store))]
        public IHttpActionResult GetStore(int id)
        {
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }

        // PUT: api/Store/5
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateStore(int id, Store store)
        {
            if (id != store.ID)
            {
                return BadRequest();
            }

            db.Entry(store).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
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

        // POST: api/Store
        [ResponseType(typeof(Store))]
        public IHttpActionResult AddStore(Store store)
        {
            db.Stores.Add(store);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = store.ID }, store);
        }

        // DELETE: api/Store/5
        [ResponseType(typeof(Store))]
        public IHttpActionResult DeleteStore(int id )
        {
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return NotFound();
            }

            //db.Stores.Remove(store);
            store.IsActive = false ;
            db.Entry(store).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(store);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StoreExists(int id)
        {
            return db.Stores.Count(e => e.ID == id) > 0;
        }
    }
}