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
    public class TVAsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: TVAs
        public async Task<ActionResult> Index()
        {
            return View(await db.TvaDb.ToListAsync());
        }

        // GET: TVAs/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVA tVA = await db.TvaDb.FindAsync(id);
            if (tVA == null)
            {
                return HttpNotFound();
            }
            return View(tVA);
        }

        // GET: TVAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TVAs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,EndDate,Rate")] TVA tVA)
        {
            if (ModelState.IsValid)
            {
                db.TvaDb.Add(tVA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tVA);
        }

        // GET: TVAs/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVA tVA = await db.TvaDb.FindAsync(id);
            if (tVA == null)
            {
                return HttpNotFound();
            }
            return View(tVA);
        }

        // POST: TVAs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,EndDate,Rate")] TVA tVA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tVA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tVA);
        }

        // GET: TVAs/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TVA tVA = await db.TvaDb.FindAsync(id);
            if (tVA == null)
            {
                return HttpNotFound();
            }
            return View(tVA);
        }

        // POST: TVAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            TVA tVA = await db.TvaDb.FindAsync(id);
            db.TvaDb.Remove(tVA);
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
