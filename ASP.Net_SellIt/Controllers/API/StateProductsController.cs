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
    [RoutePrefix("api/StateProducts")]
    public class StateProductsController : ApiController
        {
        private AppDbContext db = new AppDbContext();

        // GET: api/StateProducts
        [HttpGet]
        [Route("")]
        public IQueryable<StateProduct> GetStateProductDb()
            {
            return db.StateProductDb;
            }

        // GET: api/StateProducts/5
        [HttpGet]
        [Route("{id:long}")]
        [ResponseType(typeof(StateProduct))]
        public async Task<IHttpActionResult> GetStateProduct(long id)
            {
            StateProduct stateProduct = await db.StateProductDb.FindAsync(id);
            if (stateProduct == null)
                return NotFound();

            return Ok(stateProduct);
            }

        // PUT: api/StateProducts/5
        [HttpPut]
        [Route("{id:long}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStateProduct(long id, StateProduct stateProduct)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != stateProduct.Id)
                return BadRequest();

            db.Entry(stateProduct).State = EntityState.Modified;

            try
                {
                await db.SaveChangesAsync();
                }
            catch (DbUpdateConcurrencyException)
                {
                if (!StateProductExists(id))
                    return NotFound();
                else
                    throw;
                }

            return StatusCode(HttpStatusCode.NoContent);
            }

        // POST: api/StateProducts
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(StateProduct))]
        public async Task<IHttpActionResult> PostStateProduct(StateProduct stateProduct)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.StateProductDb.Add(stateProduct);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = stateProduct.Id }, stateProduct);
            }

        // DELETE: api/StateProducts/5
        [HttpDelete]
        [Route("{id:long}")]
        [ResponseType(typeof(StateProduct))]
        public async Task<IHttpActionResult> DeleteStateProduct(long id)
            {
            StateProduct stateProduct = await db.StateProductDb.FindAsync(id);
            if (stateProduct == null)
                return NotFound();

            db.StateProductDb.Remove(stateProduct);
            await db.SaveChangesAsync();

            return Ok(stateProduct);
            }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StateProductExists(long id)
        {
            return db.StateProductDb.Count(e => e.Id == id) > 0;
        }
    }
}