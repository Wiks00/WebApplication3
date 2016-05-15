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
    public class UserssesController : Controller
    {
        private Entities db = new Entities();

        // GET: Usersses
        public ActionResult Index()
        {
            var userss = db.USERSS.Include(u => u.EMAIL);
            return View(userss.ToList());
        }

        // GET: Usersses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userss = db.USERSS.Find(id);
            if (userss == null)
            {
                return HttpNotFound();
            }
            return View(userss);
        }

        // GET: Usersses/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Usersses/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Login,UserPassword,Email")] USERSS userss)
        {
            if (ModelState.IsValid)
            {
                db.USERSS.Add(userss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(userss);
        }

        // GET: Usersses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERSS userss = db.USERSS.Find(id);
            if (userss == null)
            {
                return HttpNotFound();
            }
            
            return View(userss);
        }

        // POST: Usersses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Login,UserPassword,Email")] USERSS userss)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(userss);
        }

        // GET: Usersses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERSS userss = db.USERSS.Find(id);
            if (userss == null)
            {
                return HttpNotFound();
            }
            return View(userss);
        }

        // POST: Usersses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USERSS userss = db.USERSS.Find(id);
            db.USERSS.Remove(userss);
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
