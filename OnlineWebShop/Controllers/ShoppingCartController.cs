using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webshop.Models;

namespace webshop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private OnlineStoreEntities db = new OnlineStoreEntities();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            var CartItems = db.CartItems.Include(c => c.Vare);
            return View(CartItems.ToList());
        }

  
    private List<CartItem> AddtoCarts(int id)
    {
      var db = new DB();
      var Cart = GetCarts();
      Cart.Add(new CartItem { VareId = id, CartId = "1", Vare = db.listAlleVare().Single(g => g.VareId == id), });
      return Cart;
    }

    // GET: ShoppingCart/Details/5
   

        // GET: ShoppingCart/Create


        // POST: ShoppingCart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,CartId,VareId")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                db.CartItems.Add(cartItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VareId = new SelectList(db.Vareer, "VareId", "ProduktNavn", cartItem.VareId);
            return View(cartItem);
        }

        // GET: ShoppingCart/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.CartItems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.VareId = new SelectList(db.Vareer, "VareId", "ProduktNavn", cartItem.VareId);
            return View(cartItem);
        }

        // POST: ShoppingCart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,CartId,VareId")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VareId = new SelectList(db.Vareer, "VareId", "ProduktNavn", cartItem.VareId);
            return View(cartItem);
        }

        // GET: ShoppingCart/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.CartItems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            return View(cartItem);
        }

        // POST: ShoppingCart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CartItem cartItem = db.CartItems.Find(id);
            db.CartItems.Remove(cartItem);
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
