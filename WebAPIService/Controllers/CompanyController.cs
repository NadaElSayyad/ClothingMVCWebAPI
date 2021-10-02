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
    public class CompanyController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Company
        public IQueryable<Company> GetCompany()
        {
            return db.Company;
        }

        // GET: api/Company/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult GetCompany(int id)
        {
            Company company = db.Company.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/Company/5
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateCompany(int id, Company company)
        {
            if (id != company.ID)
            {
                return BadRequest();
            }

            db.Entry(company).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/Company
        [ResponseType(typeof(Company))]
        public IHttpActionResult AddCompany(Company company)
        {
            db.Company.Add(company);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = company.ID }, company);
        }

        // DELETE: api/Company/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult DeleteCompany(int id)
        {
            Company company = db.Company.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            db.Company.Remove(company);
            db.SaveChanges();

            return Ok(company);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int id)
        {
            return db.Company.Count(e => e.ID == id) > 0;
        }
    }
}