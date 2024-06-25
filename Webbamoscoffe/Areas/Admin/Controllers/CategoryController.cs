    using Microsoft.Ajax.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Webbamoscoffe.Models;
namespace Webbamoscoffe.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private WebBamosEntities db = new WebBamosEntities();
        // GET: Admin/Category
        public ActionResult Index(string search)
        {
            if (search == null)
            {
                List<Category> items = db.Categories.ToList();
                return View(items);

            }
            else
            {
                List<Category> items = db.Categories.Where(row => row.category_name.Contains(search)).ToList();
                return View(items);
            }

        }

        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {
                model.created_at = DateTime.Now;
                model.slug = Webbamoscoffe.Models.Common.Filter.LocDau(model.category_name);
                db.Categories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = db.Categories.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Attach(model);
                model.created_at = DateTime.Now;
                model.slug = Webbamoscoffe.Models.Common.Filter.LocDau(model.category_name);
                db.Entry(model).Property(x => x.category_name).IsModified = true;
                db.Entry(model).Property(x => x.slug).IsModified = true;
                db.Entry(model).Property(x => x.seo_title).IsModified = true;
                db.Entry(model).Property(x => x.seo_description).IsModified = true;
                db.Entry(model).Property(x => x.seo_keywords).IsModified = true;
                db.Entry(model).Property(x => x.position).IsModified = true;
                db.Entry(model).Property(x => x.created_at).IsModified = true;
                db.Entry(model).Property(x => x.updated_at).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Categories.Find(id);
            if (item != null)
            {
                db.Categories.Remove(item);
                db.SaveChanges();

                // Trả về thông báo thành công hoặc redirect để làm mới trang index
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }

}