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
   
    [Authorize]
    public class StateProductsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: StateProducts
        public async Task<ActionResult> Index()
        {
            return View(await db.StateProductDb.ToListAsync());
        }

        // GET: StateProducts/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateProduct stateProduct = await db.StateProductDb.FindAsync(id);
            if (stateProduct == null)
            {
                return HttpNotFound();
            }
            return View(stateProduct);
        }

        // GET: StateProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StateProducts/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] StateProduct stateProduct)
        {
            if (ModelState.IsValid)
            {
                db.StateProductDb.Add(stateProduct);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(stateProduct);
        }

        // GET: StateProducts/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateProduct stateProduct = await db.StateProductDb.FindAsync(id);
            if (stateProduct == null)
            {
                return HttpNotFound();
            }
            return View(stateProduct);
        }

        // POST: StateProducts/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] StateProduct stateProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stateProduct).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(stateProduct);
        }

        // GET: StateProducts/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateProduct stateProduct = await db.StateProductDb.FindAsync(id);
            if (stateProduct == null)
            {
                return HttpNotFound();
            }
            return View(stateProduct);
        }

        // POST: StateProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            StateProduct stateProduct = await db.StateProductDb.FindAsync(id);
            db.StateProductDb.Remove(stateProduct);
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
