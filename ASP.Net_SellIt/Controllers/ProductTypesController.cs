using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityASP;
using EntityASP.Entity;
using EntityASP.Repository;

namespace ASP.Net_SellIt.Controllers
{
    //[Authorize]
    [RoutePrefix("ProductTypes")]
    public class ProductTypesController : Controller
    {
        private AppDbContext db = new AppDbContext();
        private TVARepository tvaRepository = new TVARepository(new AppDbContext());

        // GET: ProductTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.ProductTypeDb.ToListAsync());
        }

        // GET: ProductTypes/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = await db.ProductTypeDb.FindAsync(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(productType);
        }

        // GET: ProductTypes/Create
        [Route("Create")]
        public async Task<ActionResult> Create()
        {
            this.ViewBag.ListTVA = await this.tvaRepository.FindAllAsync();
            return View();
        }

        // POST: ProductTypes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Price,Name")] ProductType productType)
        {
            this.ViewBag.ListTVA = await this.tvaRepository.FindAllAsync();

            if (ModelState.IsValid)
            {
                
                long idTVA;
                long.TryParse(Request.Form.Get("ProductTypeTVAs"), out idTVA);
                TVA tva = await this.tvaRepository.FindAsync(idTVA);
                //Create a object ProductTypeTVA
                ProductTypeTVA typeTVA = new ProductTypeTVA();
                typeTVA.TVA = tva;
                typeTVA.ProductType = productType;

                //Create in database
                db.ProductTypeTvaDb.Add(typeTVA);
                db.ProductTypeDb.Add(productType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(productType);
        }

        // GET: ProductTypes/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = await db.ProductTypeDb.FindAsync(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(productType);
        }

        // POST: ProductTypes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Price,Name")] ProductType productType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productType);
        }

        // GET: ProductTypes/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = await db.ProductTypeDb.FindAsync(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(productType);
        }

        // POST: ProductTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            ProductType productType = await db.ProductTypeDb.FindAsync(id);
            db.ProductTypeDb.Remove(productType);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
