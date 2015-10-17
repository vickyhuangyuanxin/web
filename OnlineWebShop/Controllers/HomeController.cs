using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webshop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Indeks()
        {
            return View();

        }
    public ActionResult Informasjon()
    {
      return View();
    }
  }

}