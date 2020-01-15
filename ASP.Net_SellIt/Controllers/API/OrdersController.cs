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
    [RoutePrefix("api/Orders")]
    public class OrdersController : ApiController
        {
        private AppDbContext db = new AppDbContext();

        // GET: api/Orders
        [HttpGet]
        [Route("")]
        public IQueryable<Order> GetOrderDb()
            {
            return db.OrderDb;
            }

        // GET: api/Orders/5
        [HttpGet]
        [Route("{id:long}")]
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> GetOrder(long id)
            {
            Order order = await db.OrderDb.FindAsync(id);
            if (order == null)
                return NotFound();

            return Ok(order);
            }

        // PUT: api/Orders/5
        [HttpPut]
        [Route("{id:long}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrder(long id, Order order)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != order.Id)
                return BadRequest();

            db.Entry(order).State = EntityState.Modified;

            try
                {
                await db.SaveChangesAsync();
                }
            catch (DbUpdateConcurrencyException)
                {
                if (!OrderExists(id))
                    return NotFound();
                else
                    throw;
                }

            return StatusCode(HttpStatusCode.NoContent);
            }

        // POST: api/Orders
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> PostOrder(Order order)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.OrderDb.Add(order);
            await db.SaveChangesAsync();

            return CreatedAtRoute("", new { id = order.Id }, order);
            }

        // DELETE: api/Orders/5
        [HttpDelete]
        [Route("{id:long}")]
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> DeleteOrder(long id)
            {
            Order order = await db.OrderDb.FindAsync(id);
            if (order == null)
                return NotFound();

            db.OrderDb.Remove(order);
            await db.SaveChangesAsync();

            return Ok(order);
            }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(long id)
        {
            return db.OrderDb.Count(e => e.Id == id) > 0;
        }
    }
}