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
    public class CategoriesController : Controller
    {
        private Entities db = new Entities();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.CATEGORIES.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categories = db.CATEGORIES.Find(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }


        [HttpGet]
        public ActionResult GOtoItems(int? id)
        {
            CATEGORIES categories = db.CATEGORIES.Find(id);
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (categories == null)
            {
                return HttpNotFound();


            }
            
            var mySelect = db.ITEMS.Where(ty => ty.CATEGORIES.CATEGORYID == categories.CATEGORYID); 
            return View(mySelect);
        }

        public ActionResult AddToBascket(int? id)
        {
            var rdm = new Random();

            var user = db.USERSS.FirstOrDefault(i => i.LOGIN == User.Identity.Name);
            var bascket = db.BASCKET.Include(i => i.USERSS).FirstOrDefault(i => i.USERSS.LOGIN == User.Identity.Name);

            if (user == null)
            {
                user = new USERSS {USERID = rdm.Next(), EMAIL = User.Identity.Name, LOGIN = User.Identity.Name, USERPASSWORD = "undef" };
                db.USERSS.Add(user);
                db.SaveChanges();

                if (bascket == null)
                {
                    var new_basck = new BASCKET {USERID = user.USERID,BASCKETID = rdm.Next(), PHONE = rdm.Next() };
                    db.BASCKET.Add(new_basck);
                    db.SaveChanges();
                    bascket = new_basck;
                }

             
            }

            var mySelect = db.ITEMS.Find(id); 
            var item = new ITEMINBASCKET {ITEMINBASCKETID = rdm.Next(), BASCKETID = bascket.BASCKETID ,ITEMID = mySelect.ITEMID };
                    
                    db.ITEMINBASCKET.Add(item);
                    db.SaveChanges();
             return RedirectToAction("Index");

        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName")] CATEGORIES categories)
        {
            if (ModelState.IsValid)
            {

                db.CATEGORIES.Add(categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categories.ToString());
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIES categories = db.CATEGORIES.Find(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Categories/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName")] CATEGORIES categories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categories);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIES categories = db.CATEGORIES.Find(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATEGORIES categories = db.CATEGORIES.Find(id);
            db.CATEGORIES.Remove(categories);
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
