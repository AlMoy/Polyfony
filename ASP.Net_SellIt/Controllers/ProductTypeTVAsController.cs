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

namespace ASP.Net_SellIt.Controllers
{
    public class ProductTypeTVAsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        

        // GET: ProductTypeTVAs
        public async Task<ActionResult> Index()
        {
            return View(await db.ProductTypeTvaDb.ToListAsync());
        }

        // GET: ProductTypeTVAs/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTypeTVA productTypeTVA = await db.ProductTypeTvaDb.FindAsync(id);
            if (productTypeTVA == null)
            {
                return HttpNotFound();
            }
            return View(productTypeTVA);
        }

        // GET: ProductTypeTVAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductTypeTVAs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] ProductTypeTVA productTypeTVA)
        {
            if (ModelState.IsValid)
            {
                db.ProductTypeTvaDb.Add(productTypeTVA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(productTypeTVA);
        }

        // GET: ProductTypeTVAs/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTypeTVA productTypeTVA = await db.ProductTypeTvaDb.FindAsync(id);
            if (productTypeTVA == null)
            {
                return HttpNotFound();
            }
            return View(productTypeTVA);
        }

        // POST: ProductTypeTVAs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] ProductTypeTVA productTypeTVA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productTypeTVA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productTypeTVA);
        }

        // GET: ProductTypeTVAs/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTypeTVA productTypeTVA = await db.ProductTypeTvaDb.FindAsync(id);
            if (productTypeTVA == null)
            {
                return HttpNotFound();
            }
            return View(productTypeTVA);
        }

        // POST: ProductTypeTVAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            ProductTypeTVA productTypeTVA = await db.ProductTypeTvaDb.FindAsync(id);
            db.ProductTypeTvaDb.Remove(productTypeTVA);
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
