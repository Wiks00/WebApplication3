using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    public class ItemOrder1Controller : Controller
    {
        private Entities db = new Entities();

        // GET: ItemOrder1
        public ActionResult Index()
        {
            var id1 = db.ORDERS.FirstOrDefault(i => i.BASCKET.USERSS.LOGIN == User.Identity.Name).ORDERID; ;
            var itemOrder1Set = db.ITEMORDER.Include(i => i.ITEMINBASCKET).Include(i => i.ORDERS).Where(ty => ty.ITEMINBASCKET.BASCKET.USERSS.LOGIN == User.Identity.Name).Where(i => i.ORDERID == id1);
            return View(itemOrder1Set.ToList());
        }


        public ActionResult Okey()
        {
           
            return View();
        }

        public ActionResult Ok()
        {

            var id1 = db.ORDERS.FirstOrDefault(i => i.BASCKET.USERSS.LOGIN == User.Identity.Name).ORDERID;
            var order1 = db.ORDERS.FirstOrDefault( i => i.BASCKET.USERSS.LOGIN == User.Identity.Name);


            var Suma = db.ITEMORDER.Where(p => p.ITEMINBASCKET.BASCKET.USERSS.LOGIN == User.Identity.Name).Where(p => p.ORDERID == id1).ToList();
            int s = Suma.Select((t, i) => (int) Suma.ElementAt(i).ITEMINBASCKET.ITEMS.PRISELIST.PRISE).Sum();


            order1.SUMM = s;
            db.Entry(order1).State = EntityState.Modified;
            db.SaveChanges();
            
            

            return RedirectToAction("Okey");

        }

        // GET: ItemOrder1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMORDER itemOrder1 = db.ITEMORDER.Find(id);
            if (itemOrder1 == null)
            {
                return HttpNotFound();
            }
            return View(itemOrder1);
        }

        public ActionResult CreateOrder()
        {
            ViewBag.StockID = new SelectList(db.STOCK, "StockID", "Adress");
            ViewBag.ManegerID = new SelectList(db.MANAGERS, "ManagerID", "FullName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder([Bind(Include = "StockID,ManegerID")] ORDERS order)
        {
            int yourRandomStringLength = 12; //maximum: 32
            var rdm = new Random();

            string strValueStock = Request.Form["StockID"];
            string strValueManager = Request.Form["ManegerID"];

            var StockID = new SelectList(db.STOCK, "StockID", "Adress").ElementAt(int.Parse(strValueStock) - 1).Value;

            var ManagerID = new SelectList(db.MANAGERS, "ManagerID", "FullName").ElementAt(int.Parse(strValueManager) - 1).Value;

            ViewBag.StockID = new SelectList(db.STOCK, "StockID", "Adress");
            ViewBag.ManegerID = new SelectList(db.MANAGERS, "ManagerID", "FullName");
            var id1 = db.BASCKET.Where(k => k.USERSS.EMAIL == User.Identity.Name);
            order.ORDERID = rdm.Next();
            order.BASCKETID = id1.First().BASCKETID;
            order.STOCKID = int.Parse(StockID);
            order.MANEGERID = int.Parse(ManagerID);
            order.INVOICENUMBER = Guid.NewGuid().ToString("N").Substring(0, yourRandomStringLength);
            order.SUMM = 0;
            order.ORDERDATA = DateTime.Today;
            order.ARRIVEDATA = DateTime.Today.AddDays( 14);




            
             db.ORDERS.Add(order);
             db.SaveChanges();
               
            return RedirectToAction("IndexforAdd","ItemInBasckets");
           
        }

        // GET: ItemOrder1/Create
        public ActionResult Create()
        {
            ViewBag.ItemInBascketID = new SelectList(db.ITEMINBASCKET, "ItemInBascketID", "ItemInBascketID");
            ViewBag.OrderID = new SelectList(db.ORDERS, "OrderID", "InvoiceNumber");
            return View();
        }



        // POST: ItemOrder1/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemOrderID,OrderID,ItemInBascketID")] ITEMORDER itemOrder1)
        {
            if (ModelState.IsValid)
            {
                db.ITEMORDER.Add(itemOrder1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemInBascketID = new SelectList(db.ITEMINBASCKET, "ItemInBascketID", "ItemInBascketID", itemOrder1.ITEMINBASCKET);
         
            return View(itemOrder1);
        }

        // GET: ItemOrder1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMORDER itemOrder1 = db.ITEMORDER.Find(id);
            if (itemOrder1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemInBascketID = new SelectList(db.ITEMINBASCKET, "ItemInBascketID", "ItemInBascketID", itemOrder1.ITEMINBASCKET);
       
            return View(itemOrder1);
        }

        // POST: ItemOrder1/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemOrderID,OrderID,ItemInBascketID")] ITEMORDER itemOrder1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemOrder1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemInBascketID = new SelectList(db.ITEMINBASCKET, "ItemInBascketID", "ItemInBascketID", itemOrder1.ITEMINBASCKET);

            return View(itemOrder1);
        }

        // GET: ItemOrder1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var itemOrder1 = db.ITEMORDER.Find(id);
            if (itemOrder1 == null)
            {
                return HttpNotFound();
            }
            return View(itemOrder1);
        }

        // POST: ItemOrder1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ITEMORDER itemOrder1 = db.ITEMORDER.Find(id);
            db.ITEMORDER.Remove(itemOrder1);
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
