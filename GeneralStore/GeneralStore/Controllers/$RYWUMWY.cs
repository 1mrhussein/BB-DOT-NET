using GeneralStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneralStore.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Customers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer Customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Customer);
        }

        //GET Details Customer
        public ActionResult Details(int id)
        {
            Customer restaurant = db.Customers.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        public ActionResult Edit(int id)
        {
            Customer restaurant = db.Customers.Find(id);
            if (restaurant == null) // u can use != null, so reduce ur code!
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }
        //POST: Customer Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Customer);
        }

        // GET: Restaurant delete
        public ActionResult Delete(int id)
        {
            Customer Customer = db.Customers.Find(id);
            if (Customer == null)
            {
                return HttpNotFound();
            }
            return View(Customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer restaurant = db.Customers.Find(id);
            db.Customers.Remove(restaurant);
            db.SaveChanges();
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