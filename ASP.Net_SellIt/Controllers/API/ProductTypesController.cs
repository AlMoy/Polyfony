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
    [RoutePrefix("api/ProductTypes")]
    public class ProductTypesController : ApiController
        {
        private AppDbContext db = new AppDbContext();

        // GET: api/ProductTypes
        [HttpGet]
        [Route("")]
        public IQueryable<ProductType> GetProductTypeDb()
            {
            return db.ProductTypeDb;
            }

        // GET: api/ProductTypes/5
        [HttpGet]
        [Route("{id:long}")]
        [ResponseType(typeof(ProductType))]
        public async Task<IHttpActionResult> GetProductType(long id)
            {
            ProductType productType = await db.ProductTypeDb.FindAsync(id);
            if (productType == null)
                return NotFound();

            return Ok(productType);
            }

        // PUT: api/ProductTypes/5
        [HttpPut]
        [Route("{id:long}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductType(long id, ProductType productType)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != productType.Id)
                return BadRequest();

            db.Entry(productType).State = EntityState.Modified;

            try
                {
                await db.SaveChangesAsync();
                }
            catch (DbUpdateConcurrencyException)
                {
                if (!ProductTypeExists(id))
                    return NotFound();
                else
                    throw;
                }

            return StatusCode(HttpStatusCode.NoContent);
            }

        // POST: api/ProductTypes
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(ProductType))]
        public async Task<IHttpActionResult> PostProductType(ProductType productType)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.ProductTypeDb.Add(productType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productType.Id }, productType);
            }

        // DELETE: api/ProductTypes/5
        [HttpDelete]
        [Route("{id:long}")]
        [ResponseType(typeof(ProductType))]
        public async Task<IHttpActionResult> DeleteProductType(long id)
            {
            ProductType productType = await db.ProductTypeDb.FindAsync(id);
            if (productType == null)
                return NotFound();

            db.ProductTypeDb.Remove(productType);
            await db.SaveChangesAsync();

            return Ok(productType);
            }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductTypeExists(long id)
        {
            return db.ProductTypeDb.Count(e => e.Id == id) > 0;
        }
    }
}