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
    public class BascketsController : Controller
    {
        private Entities db = new Entities();
        
        // GET: Basckets
        public ActionResult Index()
        {
            var bascket = db.BASCKET.Include(i => i.BASCKETID);
            return View(bascket.ToList());
        }

        // GET: Basckets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BASCKET bascket = db.BASCKET.Find(id);
            if (bascket == null)
            {
                return HttpNotFound();
            }
            return View(bascket);
        }

        // GET: Basckets/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.USERSS, "UserID", "Login");
            return View();
        }

        // POST: Basckets/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BascketID,Phone,UserID")] BASCKET bascket)
        {
            var id1 = db.USERSS.Include(p => p.USERID);
            var id2 = new USERINF();
            bascket = new BASCKET { PHONE = decimal.Parse(id2.PHONE), USERSS = new USERSS() };
            db.SaveChanges();
            if (ModelState.IsValid)
            {
                db.BASCKET.Add(bascket);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            
            return View(bascket);
        }

        // GET: Basckets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BASCKET bascket = db.BASCKET.Find(id);
            if (bascket == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.USERSS, "UserID", "Login", bascket.USERSS.LOGIN);
            return View(bascket);
        }

        // POST: Basckets/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BascketID,Phone,UserID")] BASCKET bascket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bascket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.USERSS, "UserID", "Login", bascket.USERSS.LOGIN);
            return View(bascket);
        }

        // GET: Basckets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BASCKET bascket = db.BASCKET.Find(id);
            if (bascket == null)
            {
                return HttpNotFound();
            }
            return View(bascket);
        }

        // POST: Basckets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BASCKET bascket = db.BASCKET.Find(id);
            db.BASCKET.Remove(bascket);
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
