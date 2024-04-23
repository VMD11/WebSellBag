using SellingBags.Areas.Admin.Models.DataContext;
using SellingBags.Areas.Admin.Models.ViewModel;
using SellingBags.Common;
using SellingBags.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellingBags.Areas.Admin.Controllers
{
    public class TypeManageController : Controller
    {
        private readonly ProductTypeContext typeContext = new ProductTypeContext();
        // GET: Admin/TypeManage
        public ActionResult Index()
        {
            if (!accountSession())
            {
                return RedirectToAction("Login", "Login");
            }
            ProductTypeVM typeVM = new ProductTypeVM();
            typeVM.ProductTypes = typeContext.ProductTypes();
            return View(typeVM);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (!accountSession())
            {
                return RedirectToAction("Login", "Login");
            }
            ProductTypeVM typeVM = new ProductTypeVM();
            typeVM.Categories = typeContext.Categories();
            return View(typeVM);
        }

        [HttpPost]
        public ActionResult Create(ProductTypeVM typeVM)
        {
            ViewBag.Success = "";
            ViewBag.Error = "";
            typeVM.Categories = typeContext.Categories();
            if (ModelState.IsValid)
            {
                var Type = new ProductType
                {
                    ID_Type = GenarateRandomID.Execute(),
                    Name = typeVM.Name,
                    ID_Category = typeVM.Category
                };
                if (typeContext.Add(Type))
                {
                    ViewBag.Success = "Thêm thành công";
                    typeVM = new ProductTypeVM();
                }
                else
                {
                    ViewBag.Error = "Loại sản phẩm đã tồn tại";
                }
            }
            return View(typeVM);
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        private bool accountSession()
        {
            return Session[Sessions.ADMIN_SESSION] != null;
        }
    }
}