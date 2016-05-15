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
    public class ItemInBascketsController : Controller
    {
        private Entities db = new Entities();

        // GET: ItemInBasckets
        public ActionResult Index()
        {
            

            var itemInBascket = db.ITEMINBASCKET.Include(i => i.BASCKET).Include(i => i.ITEMS).Where(ty => ty.BASCKET.USERSS.LOGIN == User.Identity.Name);
           
            return View(itemInBascket.ToList());
        }

        public ActionResult IndexforAdd()
        {


            var itemInBascket = db.ITEMINBASCKET.Include(i => i.BASCKET).Include(i => i.ITEMS).Where(ty => ty.BASCKET.USERSS.LOGIN == User.Identity.Name);

            return View(itemInBascket.ToList());
        }

        public ActionResult GoToOrder()
        {

            return RedirectToAction("Index", "ItemOrder1");
        }
                      
        public ActionResult AddToOrder(int? id)
        {
            ITEMINBASCKET item = db.ITEMINBASCKET.Find(id);

            var rdm = new Random();

            var id1 = db.ORDERS.FirstOrDefault(i => i.BASCKET.USERSS.LOGIN == User.Identity.Name).ORDERID;

            var order = new ITEMORDER { ITEMORDERID = rdm.Next(),ITEMINBASCKETID = item.ITEMINBASCKETID, ORDERID = id1};

            db.ITEMORDER.Add(order);
            db.SaveChanges();
            return RedirectToAction("IndexforAdd","ItemInBasckets");
        }

        // GET: ItemInBasckets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMINBASCKET itemInBascket = db.ITEMINBASCKET.Find(id);
            if (itemInBascket == null)
            {
                return HttpNotFound();
            }
            return View(itemInBascket);
        }

        // GET: ItemInBasckets/Create
        public ActionResult Create()
        {
            ViewBag.BascketID = new SelectList(db.BASCKET, "BascketID", "Phone");
            ViewBag.ItemID = new SelectList(db.ITEMS, "ItemID", "ItemName");
            return View();
        }

        // POST: ItemInBasckets/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemInBascketID,BascketID,ItemID")] ITEMINBASCKET itemInBascket)
        {
            if (ModelState.IsValid)
            {
                db.ITEMINBASCKET.Add(itemInBascket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BascketID = new SelectList(db.BASCKET, "BascketID", "Phone", itemInBascket.BASCKET.BASCKETID);
            ViewBag.ItemID = new SelectList(db.ITEMS, "ItemID", "ItemName", itemInBascket.ITEMS.ITEMID);
            return View(itemInBascket);
        }

        // GET: ItemInBasckets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMINBASCKET itemInBascket = db.ITEMINBASCKET.Find(id);
            if (itemInBascket == null)
            {
                return HttpNotFound();
            }
            ViewBag.BascketID = new SelectList(db.BASCKET, "BascketID", "Phone", itemInBascket.BASCKET.BASCKETID);
            ViewBag.ItemID = new SelectList(db.ITEMS, "ItemID", "ItemName", itemInBascket.ITEMS.ITEMID);
            return View(itemInBascket);
        }

        // POST: ItemInBasckets/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemInBascketID,BascketID,ItemID")] ITEMINBASCKET itemInBascket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemInBascket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BascketID = new SelectList(db.BASCKET, "BascketID", "Phone", itemInBascket.BASCKET.BASCKETID);
            ViewBag.ItemID = new SelectList(db.ITEMS, "ItemID", "ItemName", itemInBascket.ITEMS.ITEMID);
            return View(itemInBascket);
        }

        // GET: ItemInBasckets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMINBASCKET itemInBascket = db.ITEMINBASCKET.Find(id);
            if (itemInBascket == null)
            {
                return HttpNotFound();
            }
            return View(itemInBascket);
        }

        // POST: ItemInBasckets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ITEMINBASCKET itemInBascket = db.ITEMINBASCKET.Find(id);
            db.ITEMINBASCKET.Remove(itemInBascket);
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
