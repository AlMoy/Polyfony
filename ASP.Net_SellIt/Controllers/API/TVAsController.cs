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
    [RoutePrefix("api/TVA")]
    public class TVAsController : ApiController
        {
        private AppDbContext db = new AppDbContext();

        // GET: api/TVAs
        [HttpGet]
        [Route("")]
        public IQueryable<TVA> GetTvaDb()
            {
            return db.TvaDb;
            }

        // GET: api/TVAs/5
        [HttpGet]
        [Route("{id:long}")]
        [ResponseType(typeof(TVA))]
        public async Task<IHttpActionResult> GetTVA(long id)
            {
            TVA tVA = await db.TvaDb.FindAsync(id);
            if (tVA == null)
                return NotFound();

            return Ok(tVA);
            }

        // PUT: api/TVAs/5
        [HttpPut]
        [Route("{id:long}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTVA(long id, TVA tVA)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != tVA.Id)
                return BadRequest();

            db.Entry(tVA).State = EntityState.Modified;

            try
                {
                await db.SaveChangesAsync();
                }
            catch (DbUpdateConcurrencyException)
                {
                if (!TVAExists(id))
                    return NotFound();
                else
                    throw;
                }

            return StatusCode(HttpStatusCode.NoContent);
            }

        // POST: api/TVAs
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(TVA))]
        public async Task<IHttpActionResult> PostTVA(TVA tVA)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.TvaDb.Add(tVA);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tVA.Id }, tVA);
            }

        // DELETE: api/TVAs/5
        [HttpDelete]
        [Route("{id:long}")]
        [ResponseType(typeof(TVA))]
        public async Task<IHttpActionResult> DeleteTVA(long id)
            {
            TVA tVA = await db.TvaDb.FindAsync(id);
            if (tVA == null)
                return NotFound();

            db.TvaDb.Remove(tVA);
            await db.SaveChangesAsync();

            return Ok(tVA);
            }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TVAExists(long id)
        {
            return db.TvaDb.Count(e => e.Id == id) > 0;
        }
    }
}