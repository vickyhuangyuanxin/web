using System.Collections.Generic;
using System.Web.Mvc;
using webshop.Logic;
using webshop.Models;

namespace webshop.Controllers
{
  public class ProduktController : Controller
    {
        
        public ActionResult Index()
        {
            var db = new DB();
            List<Vare> alleBestillinger = db.listAlleVare();
            return View(alleBestillinger);
        }

        public ActionResult NyVare()
        {
            return View();
        }

    

        [HttpPost]
        public ActionResult NyVare(Vare best)
        {
            var db = new DB();
            if(db.SettInnNyVare(best))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}