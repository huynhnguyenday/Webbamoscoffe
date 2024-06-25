using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbamoscoffe.Models;

namespace Webbamoscoffe.Controllers
{
    public class HotProductController : Controller
    {
        private WebBamosEntities db = new WebBamosEntities();
        // GET: HotProduct
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HotProduct()
        {
            var items = db.Drinks.Where(x => x.ishot).ToList();
            return PartialView(items);
        }
        public ActionResult SaleProduct()
        {
            var items = db.Drinks.Where(x => x.issale).ToList();
            return PartialView(items);
        }
    }
}