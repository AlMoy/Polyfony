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
using ASP.Net_SellIt.Models;
using Microsoft.AspNet.Identity;
using System.Text;
using Microsoft.AspNet.Identity.Owin;

namespace ASP.Net_SellIt.Controllers
    {
    [Authorize(Roles = "Admin")]
    public class PeopleController : Controller
        {
        private AppDbContext db = new AppDbContext();
        private PersonRepository personRepository;
        private RoleRepository roleRepository;

        public PeopleController()
            {
            this.personRepository = new PersonRepository(this.db);
            this.roleRepository = new RoleRepository(this.db);
            }

        // GET: People
        public async Task<ActionResult> Index()
            {
            return View("Index", await this.personRepository.FindAllAsync());
            }

        // GET: People/Details/5
        public async Task<ActionResult> Details(long? id)
            {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Person person = await db.PersonDb.FindAsync(id);
            if (person == null)
                return HttpNotFound();

            return View(person);
            }

        // GET: People/Create
        public async Task<ActionResult> Create()
            {
            this.ViewBag.Roles = await this.roleRepository.FindAllAsync();
            return View();
            }

        // POST: People/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,LastName,FirstName,Address,Mail,TelephoneNumber,BirthDate,Login,PassWord")] Person person)
            {
            this.ViewBag.Roles = await this.roleRepository.FindAllAsync();
            if (ModelState.IsValid)
                {
                person.Role = await this.roleRepository.FindAsync(int.Parse(Request.Form["Role"]));
                await this.personRepository.CreateAsync(person);

                return RedirectToAction("Index");
                }

            return View(person);
            }

        // GET: People/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = await this.personRepository.FindAsync(id);
            if (person == null)
            
                return HttpNotFound();

            this.ViewBag.Roles = await this.roleRepository.FindAllAsync();

            return View(person);
        }

        // POST: People/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,LastName,FirstName,Address,Mail,TelephoneNumber,BirthDate,Login,PassWord")] Person person)
        {
            this.ViewBag.Roles = await this.roleRepository.FindAllAsync();
            if (ModelState.IsValid)
            {
                await this.personRepository.UpdateAsync(person);
                return RedirectToAction("Index");
            }
            return View(person);
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
