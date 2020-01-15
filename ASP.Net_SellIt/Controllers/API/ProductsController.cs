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
using EntityASP.Repository;

namespace ASP.Net_SellIt.Controllers.API
    {
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
        {
        private AppDbContext db = new AppDbContext();

        // GET: api/Products/Stock
        [HttpGet]
        [Route("")]
        public IQueryable<Product> GetProducts()
            {
            return db.ProductDb;
            }
        // GET: api/Products/Stock
        [HttpGet]
        [Route("Stock")]
        public IQueryable<Product> GetProductsStock()
            {
            return db.ProductDb.Where(p => p.ToValid == true);
            }

        // GET: api/Products
        [HttpGet]
        [Route("NoValid")]
        public IQueryable<Product> GetProductsNoValid()
            {
            return db.ProductDb.Where(p => p.ToValid == false);
            }

        // GET: api/Products/5
        [HttpGet]
        [Route("{id:long}")]
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> GetProduct(long id)
            {
            Product product = await db.ProductDb.FindAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
            }

        // PUT: api/Products/5
        [HttpPut]
        [Route("{id:long}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(long id, Product product)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != product.Id)
                return BadRequest();

            db.Entry(product).State = EntityState.Modified;

            try
                {
                await db.SaveChangesAsync();
                }
            catch (DbUpdateConcurrencyException)
                {
                if (!ProductExists(id))
                    return NotFound();
                else
                    throw;
                }

            return StatusCode(HttpStatusCode.NoContent);
            }

        // POST: api/Products
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product product)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.ProductDb.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
            }

        // DELETE: api/Products/5
        [HttpDelete]
        [Route("{id:long}")]
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(long id)
            {
            Product product = await db.ProductDb.FindAsync(id);
            if (product == null)
                return NotFound();

            db.ProductDb.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
            }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(long id)
        {
            return db.ProductDb.Count(e => e.Id == id) > 0;
        }
    }
}