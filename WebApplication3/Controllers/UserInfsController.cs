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
    public class UserInfsController : Controller
    {
        private Entities db = new Entities();

        // GET: UserInfs
        public ActionResult Index()
        {
            return View(db.USERINF.ToList());
        }

        // GET: UserInfs/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userInf = db.USERINF.Where(i => i.USERID == id).FirstOrDefault();
            if (userInf == null)
            {
                userInf = new USERINF {USERID = (int)id ,PHONE= "444",ADRESS="fff",FULLNAME = "fff" };
            }
            return View(userInf);
        }

        // GET: UserInfs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserInfs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserInfID,FullName,Adress,Phone,UserId")] USERINF userInf )
        {
            var rdm = new Random();

            var id1 = db.USERSS.FirstOrDefault(i => i.LOGIN == User.Identity.Name).USERID;
            var users = new USERINF {USERINFID = rdm.Next(), FULLNAME = userInf.FULLNAME, ADRESS = userInf.ADRESS, PHONE = userInf.PHONE, USERID = id1};
            db.SaveChanges();
            var basket1 = new BASCKET {BASCKETID = rdm.Next() ,PHONE = Int64.Parse(userInf.PHONE), USERID = id1 };
            db.SaveChanges();

            if (ModelState.IsValid)
            {
                db.BASCKET.Add(basket1);
                db.USERINF.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(userInf);
        }

        // GET: UserInfs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERINF userInf = db.USERINF.Find(id);
            if (userInf == null)
            {
                return HttpNotFound();
            }
            return View(userInf);
        }

        // POST: UserInfs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserInfID,FullName,Adress,Phone")] USERINF userInf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userInf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userInf);
        }

        // GET: UserInfs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userInf = db.USERINF.Find(id);
            if (userInf == null)
            {
                return HttpNotFound();
            }
            return View(userInf);
        }

        // POST: UserInfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USERINF userInf = db.USERINF.Find(id);
            db.USERINF.Remove(userInf);
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
