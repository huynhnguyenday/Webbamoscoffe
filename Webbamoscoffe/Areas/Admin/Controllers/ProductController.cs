using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Webbamoscoffe.Models;

namespace Webbamoscoffe.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private WebBamosEntities db = new WebBamosEntities();

        // GET: Admin/Product
        public ActionResult Index(string search, int? categoryId)
        {
            var categories = db.Categories.Select(c => new SelectListItem
            {
                Value = c.category_id.ToString(),
                Text = c.category_name
            }).ToList();

            ViewBag.Categories = categories;

            List<Drink> items;
            if (!string.IsNullOrEmpty(search))
            {
                items = db.Drinks.Where(row => row.name.Contains(search)).ToList();
            }
            else if (categoryId.HasValue)
            {
                items = db.Drinks.Where(row => row.category_id == categoryId).ToList();
            }
            else
            {
                items = db.Drinks.ToList();
            }

            return View(items);
        }



        public ActionResult Add()
        {
            var categories = db.Categories.Select(c => new { c.category_id, c.category_name }).ToList();
            ViewBag.Category = new SelectList(categories, "category_id", "category_name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add(Drink drink)
        {
            if (ModelState.IsValid)
            {
                drink.created_at = DateTime.Now;
                drink.updated_at = DateTime.Now;
                db.Drinks.Add(drink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var categories = db.Categories.Select(c => new { c.category_id, c.category_name }).ToList();
            ViewBag.Category = new SelectList(categories, "category_id", "category_name", drink.category_id);
            return View(drink);
        }

        public ActionResult Edit(int id)
        {
            var item = db.Drinks.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            var categories = db.Categories.Select(c => new { c.category_id, c.category_name }).ToList();
            ViewBag.Category = new SelectList(categories, "category_id", "category_name", item.category_id);

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Drink model)
        {
            if (ModelState.IsValid)
            {
                var existingItem = db.Drinks.Find(model.id);
                if (existingItem == null)
                {
                    return HttpNotFound();
                }

                existingItem.name = model.name;
                existingItem.category_id = model.category_id;
                existingItem.image = model.image;
                existingItem.price = model.price;
                existingItem.sell_price = model.sell_price;
                existingItem.ishome = model.ishome;
                existingItem.ishot = model.ishot;
                existingItem.issale = model.issale;
                existingItem.updated_at = DateTime.Now;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var categories = db.Categories.Select(c => new { c.category_id, c.category_name }).ToList();
            ViewBag.Category = new SelectList(categories, "category_id", "category_name", model.category_id);

            return View(model);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var product = db.Drinks.Find(id);
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found." });
            }

            db.Drinks.Remove(product);
            db.SaveChanges();

            return Json(new { success = true, message = "Product deleted successfully." });
        }

        [HttpPost]
        public JsonResult Toggle(int id, string property)
        {
            var product = db.Drinks.Find(id);
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found." });
            }

            switch (property.ToLower())
            {
                case "ishome":
                    product.ishome = !product.ishome;
                    break;
                case "ishot":
                    product.ishot = !product.ishot;
                    break;
                case "issale":
                    product.issale = !product.issale;
                    break;
                default:
                    return Json(new { success = false, message = "Invalid property." });
            }

            db.SaveChanges();

            return Json(new { success = true, message = "Property updated successfully." });
        }
    }
}
