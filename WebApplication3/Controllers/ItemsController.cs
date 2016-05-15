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
    
    public class ItemsController : Controller
    {
       private Entities db = new Entities();

        // GET: Items
        public ActionResult Index()
        {
            var items = db.ITEMS.Include(i => i.CATEGORIES).Include(i => i.PRISELIST).Include(i => i.SUPPLIERS);
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var items = db.ITEMS.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.CATEGORIES, "CategoryID", "CategoryName");
            ViewBag.PriseListID = new SelectList(db.PRISELIST, "PriseListID", "PriseListID");
            ViewBag.SupplierID = new SelectList(db.SUPPLIERS, "SupplierID", "SupplierName");
            return View();
        }

        // POST: Items/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ItemName,PriseListID,SupplierID,CategoryID")] ITEMS items)
        {
            if (ModelState.IsValid)
            {
                db.ITEMS.Add(items);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.CATEGORIES, "CategoryID", "CategoryName", items.CATEGORYID);
            ViewBag.PriseListID = new SelectList(db.PRISELIST, "PriseListID", "PriseListID", items.PRISELISTID);
            ViewBag.SupplierID = new SelectList(db.SUPPLIERS, "SupplierID", "SupplierName", items.SUPPLIERID);
            return View(items);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMS items = db.ITEMS.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.CATEGORIES, "CategoryID", "CategoryName", items.CATEGORYID);
            ViewBag.PriseListID = new SelectList(db.PRISELIST, "PriseListID", "PriseListID", items.PRISELISTID);
            ViewBag.SupplierID = new SelectList(db.SUPPLIERS, "SupplierID", "SupplierName", items.SUPPLIERID);
            return View(items);
        }

        // POST: Items/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemName,PriseListID,SupplierID,CategoryID")] ITEMS items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.CATEGORIES, "CategoryID", "CategoryName", items.CATEGORYID);
            ViewBag.PriseListID = new SelectList(db.PRISELIST, "PriseListID", "PriseListID", items.PRISELISTID);
            ViewBag.SupplierID = new SelectList(db.SUPPLIERS, "SupplierID", "SupplierName", items.SUPPLIERID);
            return View(items);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var items = db.ITEMS.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var items = db.ITEMS.Find(id);
            db.ITEMS.Remove(items);
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
