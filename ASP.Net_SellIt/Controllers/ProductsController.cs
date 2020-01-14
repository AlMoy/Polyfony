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
using System.Data.Entity.Core;

namespace ASP.Net_SellIt.Controllers
    {
    [Authorize]
    [RoutePrefix("Products")]
    public class ProductsController : Controller
        {
        private AppDbContext db = new AppDbContext();
        private ProductRepository productRepository;
        private ProductTypeRepository productTypeRepository;

        public ProductsController()
            {
            this.productRepository = new ProductRepository(this.db);
            this.productTypeRepository = new ProductTypeRepository(this.db);
            }

        // GET: Products
        [HttpGet]
        [Route("ListProducts/Stock")]
        public async Task<ActionResult> ProductsStock()
            {
            List<Product> products = await this.productRepository.FindAllAsync();
            return View("ListProducts", products.Where(ps => ps.ToValid == true));
            }

        // GET: Products
        [HttpGet]
        [Route("ListProducts/NoValid")]
        public async Task<ActionResult> ProductNoValid()
            {
            List<Product> products = await this.productRepository.FindAllAsync();
            return View("ListProducts", products.Where(ps => ps.ToValid == false));
            }

        // GET: Products/Details/5
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<ActionResult> Details(long? id)
            {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = await this.productRepository.FindAsync(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
            }

        // GET: Products/Create
        [HttpGet]
        [Authorize]
        [Route("Create")]
        public async Task<ActionResult> Create()
            {
            this.ViewBag.ProductTypes = await this.productTypeRepository.FindAllAsync();
            return View();
            }

        // POST: Products/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Size,Weight,Color,ToValid")] Product product)
            {
            this.ViewBag.ProductTypes = await this.productTypeRepository.FindAllAsync();

            if (ModelState.IsValid)
                {
                product.ProductType = await this.productTypeRepository.FindAsync(int.Parse(Request.Form["ProductType"]));
                await this.productRepository.CreateAsync(product);

                List<Product> products = await this.productRepository.FindAllAsync();
                return RedirectToAction("Details", new { id = product.Id });
                }

            return View(product);
            }

        // GET: Products/Edit/5
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Edit/{id}")]
        public async Task<ActionResult> Edit(long? id)
            {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = await this.productRepository.FindAsync(id);
            if (product == null)
                return HttpNotFound();

            this.ViewBag.ProductTypes = await this.productTypeRepository.FindAllAsync();

            return View(product);
            }

        // POST: Products/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Size,Weight,Color,ToValid")] Product product)
            {
            this.ViewBag.ProductTypes = await this.productTypeRepository.FindAllAsync();

            if (ModelState.IsValid)
                {
                Boolean toValid;
                Boolean.TryParse(Request.Form["ToValid"], out toValid);
                product.ToValid = toValid;

                long quantity;
                long.TryParse(Request.Form["Quantity"], out quantity);
                product.Quantity = quantity;
                await this.productRepository.UpdateAsync(product);
                return RedirectToAction("Details", new { id = product.Id });
                }
            return View(product);
            }

        // GET: Products/Delete/5
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(long? id)
            {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = await this.productRepository.FindAsync(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
            }

        // POST: Products/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
            {
            Product product = await this.productRepository.FindAsync(id);
            await this.productRepository.Remove(product);
            return RedirectToAction("ListProducts/Stock");
            }

        // POST: Products/Validate/5
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Validate")]
        public async Task<ActionResult> Validate(long? id)
            {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = await this.productRepository.FindAsync(id);
            if (product == null)
                return HttpNotFound();

            product.ToValid = true;
            await this.productRepository.UpdateAsync(product);

            return RedirectToAction("ListProducts/NoValid");
            }


        protected override void Dispose(bool disposing)
            {
            if (disposing)
                this.db.Dispose();

            base.Dispose(disposing);
            }
        }
    }