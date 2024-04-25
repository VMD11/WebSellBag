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
    public class BrandManageController : Controller
    {
        private readonly BrandContext brandContext = new BrandContext();
        // GET: Admin/BrandManage
        public ActionResult Index()
        {
            if (!accountSession())
            {
                return RedirectToAction("Index", "Login");
            }
            BrandVM brandVM = new BrandVM();
            brandVM.Brands = brandContext.Brands();
            return View(brandVM);
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (!accountSession())
            {
                return RedirectToAction("Index", "Login");
            }
            BrandVM brandVM = new BrandVM();
            return View(brandVM);
        }

        [HttpPost]
        public ActionResult Create(BrandVM brandVM)
        {
            if (ModelState.IsValid)
            {
                if(brandVM.ImageFile != null && brandVM.ImageFile.ContentLength > 0)
                {
                    var Brand = new Brand();
                    Brand.ID_Brand = GenarateRandomID.Execute();
                    Brand.Name = brandVM.Name;
                    Brand.ImageURL = brandVM.ImageFile.FileName;
                    string fileName = Path.GetFileName(brandVM.ImageFile.FileName);
                    string imagePath = Path.Combine(Server.MapPath("~/Assets/images/brands"), fileName);
                    brandVM.ImageFile.SaveAs(imagePath);
                    if (brandContext.Add(Brand))
                    {
                        ViewBag.Message = "Thêm thành công";
                        brandVM = new BrandVM();
                    }
                    else
                    {
                        ViewBag.Error = "Thương hiệu đã tồn tại";
                    }

                }
                else
                {
                    ViewBag.Error = "Không tìm thấy file ảnh";
                }
            }
            else
            {
                ViewBag.Error = "Tên không được bỏ trống";
            }
            return View(brandVM);
        }
        [HttpGet]
        public ActionResult Update(string ID_Brand)
        {
            if (!accountSession())
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Success = "";
            ViewBag.Error = "";
            BrandVM brandVM = new BrandVM();
            brandVM.Brand = brandContext.GetBrand(ID_Brand);
            return View(brandVM);
        }
        [HttpPost]
        public ActionResult Update(BrandVM brandVM)
        {
            ViewBag.Success = "";
            ViewBag.Error = "";
            brandVM.Brand = brandContext.GetBrand(brandVM.ID_Brand);
            if (ModelState.IsValid)
            {
                var Brand = new Brand
                {
                    ID_Brand = brandVM.ID_Brand,
                    Name = brandVM.Name,
                };
                if (brandVM.ImageFile != null && brandVM.ImageFile.ContentLength > 0)
                {
                    Brand.ImageURL = brandVM.ImageFile.FileName;
                    string fileName = Path.GetFileName(brandVM.ImageFile.FileName);
                    string imagePath = Path.Combine(Server.MapPath("~/Assets/images/brands"), fileName);
                    brandVM.ImageFile.SaveAs(imagePath);
                }
                else
                {
                    Brand.ImageURL = brandContext.GetBrand(brandVM.ID_Brand).ImageURL;
                }
                if (brandContext.Update(Brand))
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
            return View(brandVM);
        }

        public ActionResult Detail(string ID_Brand)
        {
            if (!accountSession())
            {
                return RedirectToAction("Index", "Login");
            }
            Brand Brand = brandContext.GetBrand(ID_Brand);
            return View(Brand);
        }

        public ActionResult Delete(string ID_Brand)
        {
            if (brandContext.Delete(ID_Brand))
            {
                return Json(new { result = true });
            }
            return Json(new { result = false });
        }

        private bool accountSession()
        {
            return Session[Sessions.ADMIN_SESSION] != null;
        }
    }
}