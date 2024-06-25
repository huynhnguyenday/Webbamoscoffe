using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbamoscoffe.Models;

namespace Webbamoscoffe.Controllers
{
    public class PartialViewController : Controller
    {
        private WebBamosEntities db = new WebBamosEntities();
        // GET: PartialView
        public ActionResult Category()
        {
            var categories = db.Categories.ToList();
            return PartialView(categories);
        }


    }
}