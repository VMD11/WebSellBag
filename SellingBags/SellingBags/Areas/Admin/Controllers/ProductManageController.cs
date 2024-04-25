using SellingBags.Areas.Admin.Models.DataContext;
using SellingBags.Areas.Admin.Models.ViewModel;
using SellingBags.Common;
using SellingBags.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellingBags.Areas.Admin.Controllers
{
    public class ProductManageController : Controller
    {
        private readonly ProductContext productContext = new ProductContext();
        // GET: Admin/Product
        public ActionResult Index()
        {
            if (!accountSession())
            {
                return RedirectToAction("Index","Login");
            }
            ProductVM productVM = new ProductVM();
            productVM.ProductsAll = productContext.GetProducts();

            return View(productVM);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (!accountSession())
            {
                return RedirectToAction("Index","Login");
            }
            ProductVM productVM = new ProductVM();
            ViewBag.Brands = productContext.GetBrands();
            ViewBag.Categories = productContext.GetCategories();
            ViewBag.ProductTypes = productContext.GetProductTypes();
            return View(productVM);
        }

        [HttpPost]
        public ActionResult Create(ProductVM productVM)
        {
            ViewBag.Success = "";
            ViewBag.Error = "";
            ViewBag.Brands = productContext.GetBrands();
            ViewBag.Categories = productContext.GetCategories();
            ViewBag.ProductTypes = productContext.GetProductTypes();
            if (productVM.ImageFile != null && productVM.ImageFile.ContentLength > 0)
            {
                Product product = new Product
                {
                    ID_Product = GenarateRandomID.Execute(),
                    Name = productVM.Name,
                    Color = productVM.Color,
                    Size = productVM.Size,
                    Price = productVM.Price,
                    Quantity = productVM.Quantity,
                    Description = productVM.Description,
                    ImageURL = productVM.ImageFile.FileName,
                    ID_Type = productVM.Type,
                    ID_Brand = productVM.Brand,
                    DateCreated = GenarateDate.Execute(),
                };
                string fileName = Path.GetFileName(productVM.ImageFile.FileName);
                string imagePath = Path.Combine(Server.MapPath("~/Assets/images/products"), fileName);
                productVM.ImageFile.SaveAs(imagePath);
                if (productContext.Add(product))
                {
                    ViewBag.Success = "Thêm mới thành công";
                    productVM = new ProductVM();
                    //return Json(new {success = true});
                }
                else
                {
                    ViewBag.Error = "Thêm mới thất bại";
                }
            }
            //return Json(new {success = false});
            return View(productVM);

        }

        public ActionResult Delete(string ID_Product)
        {
            return Json(new {result = productContext.Delete(ID_Product)});
        }

        public ActionResult Detail(string ID_Product)
        {
            if (!accountSession())
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Brand = productContext.GetBrandName(ID_Product);
            ViewBag.Type = productContext.GetTypeName(ID_Product);
            return View(productContext.GetProduct(ID_Product));
        }

        [HttpGet]
        public ActionResult Update(string ID_Product)
        {
            if (!accountSession())
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Success = "";
            ViewBag.Error = "";
            ProductVM productVM = new ProductVM();
            productVM.Product = productContext.GetProduct(ID_Product);
            productVM.Brands = productContext.GetBrands();
            productVM.ProductTypes = productContext.GetProductTypes(productContext.GetProductType(productVM.Product.ID_Type).ID_Category);
            return View(productVM);
        }
        [HttpPost]
        public ActionResult Update(ProductVM productVM)
        {
            ViewBag.Success = "";
            ViewBag.Error = "";
            productVM.Product = productContext.GetProduct(productVM.ID_Product);
            productVM.Brands = productContext.GetBrands();
            productVM.ProductTypes = productContext.GetProductTypes(productContext.GetProductType(productVM.Type).ID_Category);
            var product = new Product
            {
                ID_Product = productVM.ID_Product,
                Name = productVM.Name,
                Color = productVM.Color,
                Size = productVM.Size,
                Price = productVM.Price,
                Quantity = productVM.Quantity,
                Description = productVM.Description,
                ID_Brand = productVM.Brand,
                ID_Type = productVM.Type,
            };
            Debug.WriteLine(productVM);
            if (productVM.ImageFile != null && productVM.ImageFile.ContentLength > 0)
            {
                product.ImageURL = productVM.ImageFile.FileName;
                string fileName = Path.GetFileName(productVM.ImageFile.FileName);
                string imagePath = Path.Combine(Server.MapPath("~/Assets/images/products"), fileName);
                productVM.ImageFile.SaveAs(imagePath);
            }
            else
            {
                product.ImageURL = productVM.Product.ImageURL;
                Debug.WriteLine(product.ImageURL);
            }
            if (productContext.Update(product))
            {
                ViewBag.Success = "Cập nhật thành công";
            }
            else { ViewBag.Error = "Cập nhật thất bại"; }
            return View(productVM);
        }

        private bool accountSession()
        {
            return Session[Sessions.ADMIN_SESSION] != null;
        }
    }
}