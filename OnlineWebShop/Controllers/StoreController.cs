using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using webshop.Models;
using webshop.Logic;
using System;

namespace webshop.Controllers
{
    public class StoreController : Controller
    {

        public ActionResult Index()
        {

      var db = new DB();
      List<Vare> alleBestillinger = db.listAlleVare();
      return View(alleBestillinger);
    
        }

        //   [Authorize]
      //  public ActionResult Buy(int id)
      //  {
      //   var db = new DB();
      //// Vare vare = db.listAlleVare().Single(a => a.VareId == id);
      ////put the item in to cart
      //List<CartItem> cart = this.AddtoCarts(id) ;
      //      return View(cart);
      //  }

    


    //private List<CartItem> GetCarts()
    //    {
    //  var db = new DB();
    //  var cart = new List<CartItem>{
    //            new CartItem { VareId = 1, CartId = "1", Vare = db.listAlleVare().Single(g => g.VareId == 1) },
    //            new CartItem { VareId = 3, CartId = "1", Vare = db.listAlleVare().Single(g => g.VareId == 3) }
    //        };
    //        return cart;
    //    }
    //private List<CartItem> AddtoCarts(int id)
    //{
    //  var db = new DB();
    //  var Cart = GetCarts();
    //  Cart.Add(new CartItem { VareId = id, CartId = "1", Vare = db.listAlleVare().Single(g => g.VareId == id) });
    //  return Cart;
    //}
  }
}
