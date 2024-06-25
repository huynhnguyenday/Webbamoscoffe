using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbamoscoffe.Models;
namespace Webbamoscoffe.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private WebBamosEntities db = new WebBamosEntities();
        // GET: Admin/Order
        public ActionResult Index(string search)
        {
            if (search == null)
            {
                List<Order> items = db.Orders.ToList();
                return View(items);

            }
            else
            {
                List<Customer> items = db.Customers.Where(row => row.name.Contains(search)).ToList();
                return View(items);
            }

        }

        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Order model)
        {
            if (ModelState.IsValid)
            {
                
                db.Orders.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = db.Orders.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order model)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Attach(model);
                db.Entry(model).Property(x => x.order_id).IsModified = true;
                db.Entry(model).Property(x => x.customer_id).IsModified = true;
                db.Entry(model).Property(x => x.total_amount).IsModified = true;
                db.Entry(model).Property(x => x.status).IsModified = true;
                db.Entry(model).Property(x => x.payment_id).IsModified = true;
                db.Entry(model).Property(x => x.Customer).IsModified = true;
                /*db.Entry(model).Property(x => x.created_at).IsModified = true;
                db.Entry(model).Property(x => x.updated_at).IsModified = true;*/
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Orders.Find(id);
            if (item != null)
            {
                db.Orders.Remove(item);
                db.SaveChanges();

                // Trả về thông báo thành công hoặc redirect để làm mới trang index
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }

}