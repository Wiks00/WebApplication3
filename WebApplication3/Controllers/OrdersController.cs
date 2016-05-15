using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class OrdersController : Controller
    {
       private Entities db = new Entities();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.ORDERS.Include(o => o.MANAGERS).Include(o => o.STOCK).Where(p => p.BASCKET.USERSS.LOGIN == User.Identity.Name);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orders = db.ORDERS.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.ManegerID = new SelectList(db.MANAGERS, "ManagerID", "FullName");
            ViewBag.StockID = new SelectList(db.SUPPLIERS, "StockID", "Adress");
            ViewBag.OrderID = new SelectList(db.ITEMORDER, "ItemOrderID", "ItemOrderID");
            return View();
        }

        // POST: Orders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,StockID,ManegerID,OrderData,ArriveData,InvoiceNumber,Summ,ItemOrderId")] ORDERS orders)
        {
            if (ModelState.IsValid)
            {
                db.ORDERS.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManegerID = new SelectList(db.MANAGERS, "ManagerID", "FullName", orders.MANEGERID);
            ViewBag.StockID = new SelectList(db.STOCK, "StockID", "Adress", orders.STOCKID);
            ViewBag.OrderID = new SelectList(db.ITEMORDER, "ItemOrderID", "ItemOrderID", orders.ORDERID);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orders = db.ORDERS.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManegerID = new SelectList(db.MANAGERS, "ManagerID", "FullName", orders.MANEGERID);
            ViewBag.StockID = new SelectList(db.STOCK, "StockID", "Adress", orders.STOCKID);
            ViewBag.OrderID = new SelectList(db.ITEMORDER, "ItemOrderID", "ItemOrderID", orders.ORDERID);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,BascketID,StockID,ManegerID,OrderData,ArriveData,InvoiceNumber,Summ,ItemOrderId")] ORDERS orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManegerID = new SelectList(db.MANAGERS, "ManagerID", "FullName", orders.MANEGERID);
            ViewBag.StockID = new SelectList(db.STOCK, "StockID", "Adress", orders.STOCKID);
            ViewBag.OrderID = new SelectList(db.ITEMORDER, "ItemOrderID", "ItemOrderID", orders.ORDERID);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orders = db.ORDERS.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var orders = db.ORDERS.Find(id);
            db.ORDERS.Remove(orders);
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
