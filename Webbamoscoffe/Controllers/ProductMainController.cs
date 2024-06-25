using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbamoscoffe.Models;

namespace Webbamoscoffe.Controllers
{
    public class ProductMainController : Controller
    {
        private WebBamosEntities db = new WebBamosEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var item = db.Drinks.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        public ActionResult ProductMain()
        {
            var items = db.Drinks.Where(x => x.ishome).ToList();
            return PartialView(items);
        }
    }
}
