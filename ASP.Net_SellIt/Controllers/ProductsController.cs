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
    public class ProductsController : Controller
        {
        private AppDbContext db = new AppDbContext();
        private ProductRepository productRepository = new ProductRepository(new AppDbContext());

        // GET: Products
        public async Task<ActionResult> Index()
            {
            return View(await productRepository.FindAllAsync());
            }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(long? id)
            {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = await productRepository.FindAsync(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
            }

        // GET: Products/Create
        public ActionResult Create()
            {
            return View();
            }

        // POST: Products/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Size,Weight,Color,ToValid")] Product product)
            {
            if (ModelState.IsValid)
                {
                await productRepository.CreateAsync(product);
                return RedirectToAction("Index");
                }

            return View(product);
            }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(long? id)
            {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = await productRepository.FindAsync(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
            }

        // POST: Products/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Size,Weight,Color,ToValid")] Product product)
            {
            if (ModelState.IsValid)
                {
                await productRepository.UpdateAsync(product);
                return RedirectToAction("Index");
                }
            return View(product);
            }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(long? id)
            {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = await productRepository.FindAsync(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
            }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
            {
            Product product = await productRepository.FindAsync(id);
            await productRepository.Remove(product);
            return RedirectToAction("Index");
            }

        protected override void Dispose(bool disposing)
            {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
            }
        }
    }
