using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbamoscoffe.Models;
using Microsoft.Ajax.Utilities;
using PagedList;
namespace Webbamoscoffe.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private WebBamosEntities db = new WebBamosEntities();
        // GET: Admin/News
        public ActionResult Index(string search, int? page)
        {
            /*var pageSize = 10;
            if (pageSize == null)
            {
                page = -1;
            }
            IEnumerable<Adv> items = db.Advs.OrderByDescending(x => x.id);*/
            if (search == null)
            {
                List<Adv> items = db.Advs.ToList();
                return View(items);

            }
            else
            {
                List<Adv> items = db.Advs.Where(row => row.title.Contains(search)).ToList();
                return View(items);
            }
            /*var pageIndex = page.HasValue ? Convert.ToInt32(page) : 0;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);*/

        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Add(Adv model)
        {
            if (ModelState.IsValid)
            {
                model.created_at = DateTime.Now;
                model.updated_at = DateTime.Now;
                db.Advs.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = db.Advs.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Adv model)
        {
            if (ModelState.IsValid)
            {
                // Lấy ngày tạo ban đầu từ database
                var existingItem = db.Advs.AsNoTracking().FirstOrDefault(x => x.id == model.id);
                if (existingItem != null)
                {
                    model.created_at = existingItem.created_at; // Giữ nguyên ngày tạo ban đầu
                }

                model.updated_at = DateTime.Now; // Cập nhật ngày cập nhật

                db.Advs.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Advs.Find(id);
            if (item != null)
            {
                db.Advs.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}