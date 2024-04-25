using SellingBags.Areas.Admin.Models.DataContext;
using SellingBags.Areas.Admin.Models.ViewModel;
using SellingBags.Common;
using SellingBags.Models;
using SellingBags.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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
                return RedirectToAction("Index", "Login");
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
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Success = "";
            ViewBag.Error = "";
            ProductTypeVM typeVM = new ProductTypeVM();
            ViewBag.Categories = typeContext.Categories();
            return View(typeVM);
        }

        [HttpPost]
        public ActionResult Create(ProductTypeVM typeVM)
        {
            ViewBag.Success = "";
            ViewBag.Error = "";
            ViewBag.Categories = typeContext.Categories();
            if (ModelState.IsValid)
            {
                var Type = new ProductType
                {
                    ID_Type = GenarateRandomID.Execute(),
                    Name = typeVM.Name,
                    ID_Category = typeVM.Category
                };
                if (typeVM.ImageFile != null && typeVM.ImageFile.ContentLength > 0)
                {
                    Type.ImageURL = typeVM.ImageFile.FileName;
                    string fileName = Path.GetFileName(typeVM.ImageFile.FileName);
                    string imagePath = Path.Combine(Server.MapPath("~/Assets/images/prodtypes"), fileName);
                    typeVM.ImageFile.SaveAs(imagePath);
                }
                else { Type.ImageURL = null; }
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
            else
            {
                ViewBag.Error = "Tên không được bỏ trống";
            }
            return View(typeVM);
        }

        [HttpGet]
        public ActionResult Update(string ID_Type)
        {
            if (!accountSession())
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Success = "";
            ViewBag.Error = "";
            ProductTypeVM typeVM = new ProductTypeVM();
            typeVM.ProductType = typeContext.GetType(ID_Type);
            typeVM.Categories = typeContext.Categories();
            return View(typeVM);
        }
        [HttpPost]
        public ActionResult Update(ProductTypeVM typeVM)
        {
            ViewBag.Success = "";
            ViewBag.Error = "";
            typeVM.ProductType = typeContext.GetType(typeVM.ID_Type);
            typeVM.Categories = typeContext.Categories();
            if(ModelState.IsValid)
            {
                var Type = new ProductType
                {
                    ID_Type = typeVM.ID_Type,
                    Name = typeVM.Name,
                    ID_Category = typeVM.Category
                };
                if(typeVM.ImageFile != null && typeVM.ImageFile.ContentLength > 0)
                {
                    Type.ImageURL = typeVM.ImageFile.FileName;
                    string fileName = Path.GetFileName(typeVM.ImageFile.FileName);
                    string imagePath = Path.Combine(Server.MapPath("~/Assets/images/prodtypes"), fileName);
                    typeVM.ImageFile.SaveAs(imagePath);
                }
                else
                {
                    Type.ImageURL = typeContext.GetType(typeVM.ID_Type).ImageURL;
                }
                if(typeContext.Update(Type))
                {
                    ViewBag.Success = "Cập nhật thành công";
                }
                else
                {
                    ViewBag.Error = "Cập nhật không thành công";
                }
            }
            else
            {
                ViewBag.Error = "Tên không được bỏ trống";
            }
            return View(typeVM);
        }

        public ActionResult Detail(string ID_Type)
        {
            if (!accountSession())
            {
                return RedirectToAction("Index", "Login");
            }
            ProductType productType = typeContext.GetType(ID_Type);
            ViewBag.Category = typeContext.GetCategory(productType.ID_Category);
            return View(productType);
        }

        public ActionResult Delete(string ID_Type)
        {
            if (typeContext.Delete(ID_Type))
            {
                return Json(new {result = true});
            }
            return Json(new { result = false});
        }

        private bool accountSession()
        {
            return Session[Sessions.ADMIN_SESSION] != null;
        }
    }
}