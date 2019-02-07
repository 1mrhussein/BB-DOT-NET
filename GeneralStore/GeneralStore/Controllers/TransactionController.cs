using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GeneralStore.Models;

namespace GeneralStore.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Product product { get; private set; }

        // GET: Transaction
        public ActionResult Index()
        {
            var transactions = db.Transactions.Include(t => t.Customer).Include(t => t.Product);
            return View(transactions.ToList());
        }

        // GET: Transaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerFullName");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionID,ProductID,CustomerID,DateOfTransaction")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                var QttInStock = db.Products.Find(transaction.ProductID);

                if (QttInStock.Quantity > 0)
                {
                    QttInStock.Quantity -= 1;

                    db.Transactions.Add(transaction);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    // Redirect to page that has info Like this:
                    return RedirectToAction("Index", "Customer");
                }
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerFullName", transaction.CustomerID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", transaction.ProductID);
            return View(transaction);
        }
        // GET: Transaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerFullName", transaction.CustomerID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", transaction.ProductID);
            return View(transaction);
        }

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionID,ProductID,CustomerID,DateOfTransaction")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerFullName", transaction.CustomerID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", transaction.ProductID);
            return View(transaction);
        }

        // GET: Transaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
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
