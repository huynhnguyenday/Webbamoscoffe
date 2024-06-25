using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbamoscoffe.Models;

namespace Webbamoscoffe.Controllers
{
    public class CartController : Controller
    {
        WebBamosEntities db = new WebBamosEntities();

        private List<Cart_Item> GetCart()
        {
            var cart = Session["Cart"] as List<Cart_Item>;
            if (cart == null)
            {
                cart = new List<Cart_Item>();
                Session["Cart"] = cart;
            }
            return cart;
        }

        [HttpPost]
        public ActionResult AddToCart(int id, int quantity = 1)
        {
            var product = FindProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var cart = GetCart();
            var existingItem = cart.Find(item => item.product_id == id);
            if (existingItem != null)
            {
                existingItem.quantity += quantity;
            }
            else
            {
                cart.Add(new Cart_Item { product_id = id, quantity = quantity, price = product.price, Drink = product });
            }
            Session["Cart"] = cart;
            return Json(new { success = true, message = "Sản phẩm đã được thêm vào giỏ hàng thành công." });
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = GetCart();
            var itemToRemove = cart.FirstOrDefault(item => item.product_id == id);
            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
                Session["Cart"] = cart;
                return Json(new { success = true, message = "Sản phẩm đã được xóa khỏi giỏ hàng." });
            }
            else
            {
                return Json(new { success = false, message = "Không tìm thấy sản phẩm trong giỏ hàng." });
            }
        }

        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult Checkout()
        {
            return View(GetCart());
        }

        private Drink FindProductById(int id)
        {
            return db.Drinks.FirstOrDefault(p => p.id == id);
        }

        [HttpPost]
        public JsonResult UpdateCartItemQuantity(int id, int quantity)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.product_id == id);
            if (item != null)
            {
                item.quantity = quantity;
                Session["Cart"] = cart;

                var total = item.quantity * item.price;
                return Json(new { success = true, total });
            }
            return Json(new { success = false });
        }
    }
}
