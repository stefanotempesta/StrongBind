using SampleMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TempestaSpace.Mvc.StrongBind;

namespace SampleMvc.Controllers
{
    public class PeopleController : Controller
    {
        private SampleMvcDataContext db = new SampleMvcDataContext();

        // GET: People
        public ActionResult Index()
        {
            var people = db.People
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToList();

            return View(people);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,FirstName,MiddleName,LastName,DateOfBirth,Email")]Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,
            // Change of Email not allowed
            [Bind(Include = "Id,FirstName,MiddleName,LastName,DateOfBirth")]
            //[Bind(Exclude = "Email")]
            //[Bind(Include =
            //    nameof(Person.Id) + "," +
            //    nameof(Person.FirstName) + "," +
            //    nameof(Person.MiddleName) + "," +
            //    nameof(Person.LastName) + "," +
            //    nameof(Person.DateOfBirth))]
            Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(person);
        }

        public ActionResult EditUnsafe(int id)
        {
            var person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View("Edit", person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUnsafe(int id, Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Edit", person);
        }

        public ActionResult EditSafe(int id)
        {
            var person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View("Edit", person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSafe(int id, [StrongBind] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Edit", person);
        }
    }
}
