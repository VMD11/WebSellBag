using SellingBags.Common;
using SellingBags.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellingBags.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Cart()
        {
            VirtualCartContext cart = Session[Sessions.CART] as VirtualCartContext;
            if (cart == null)
            {
                cart = new VirtualCartContext();
            }

            Session[Sessions.CART] = cart;
            return View(Session[Sessions.CART] as VirtualCartContext);
        }

        public ActionResult Add(string ID_Product, int Quantity)
        {
            VirtualCartContext cart = Session[Sessions.CART] as VirtualCartContext;
            if (cart == null)
            {
                cart = new VirtualCartContext();
            }

            cart.AddProduct(ID_Product, Quantity);
            Session[Sessions.CART] = cart;

            return RedirectToAction("Cart");
        }

        public decimal Update(string ID_Product, int Quantity)
        {
            VirtualCartContext cart = Session[Sessions.CART] as VirtualCartContext;
            if (cart == null)
            {
                return 0;
            }
            cart.UpdateProduct(ID_Product, Quantity);
            Session[Sessions.CART] = cart;

            return cart.TotalMoney();
        }

        public decimal Delete(string ID_Product)
        {
            VirtualCartContext cart = Session[Sessions.CART] as VirtualCartContext;
            if (cart == null)
            {
                return 0;
            }
            cart.DeleteProduct(ID_Product);
            Session[Sessions.CART] = cart;

            return cart.TotalMoney();
        }

    }
}