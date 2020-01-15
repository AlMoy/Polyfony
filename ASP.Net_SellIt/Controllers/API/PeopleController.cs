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
using EntityASP;
using EntityASP.Entity;

namespace ASP.Net_SellIt.Controllers.API
    {
    [RoutePrefix("api/People")]
    public class PeopleController : ApiController
        {
        private AppDbContext db = new AppDbContext();

        // GET: api/People
        [HttpGet]
        [Route("")]
        public IQueryable<Person> GetPerson()
            {
            return db.PersonDb;
            }

        // GET: api/People/Clients
        [HttpGet]
        [Route("Clients")]
        public IQueryable<Person> GetClients()
            {
            return db.PersonDb.Where(p => p.Role.Name == "Client");
            }

        // GET: api/People/Sellers
        [HttpGet]
        [Route("Sellers")]
        public IQueryable<Person> GetSellers()
            {
            return db.PersonDb.Where(p => p.Role.Name == "Vendeur");
            }

        // GET: api/People/5
        [HttpGet]
        [Route("{id:long}")]
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> GetPerson(long id)
            {
            Person person = await db.PersonDb.FindAsync(id);
            if (person == null)
                return NotFound();

            return Ok(person);
            }

        // PUT: api/People/5
        [HttpPut]
        [Route("{id:long}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPerson(long id, Person person)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != person.Id)
                return BadRequest();

            db.Entry(person).State = EntityState.Modified;

            try
                {
                await db.SaveChangesAsync();
                }
            catch (DbUpdateConcurrencyException)
                {
                if (!PersonExists(id))
                    return NotFound();
                else
                    throw;
                }

            return StatusCode(HttpStatusCode.NoContent);
            }

        // POST: api/People
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> PostPerson(Person person)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.PersonDb.Add(person);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
            }

        // DELETE: api/People/5
        [HttpDelete]
        [Route("{id:long}")]
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> DeletePerson(long id)
            {
            Person person = await db.PersonDb.FindAsync(id);
            if (person == null)
                return NotFound();

            db.PersonDb.Remove(person);
            await db.SaveChangesAsync();

            return Ok(person);
            }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(long id)
        {
            return db.PersonDb.Count(e => e.Id == id) > 0;
        }
    }
}