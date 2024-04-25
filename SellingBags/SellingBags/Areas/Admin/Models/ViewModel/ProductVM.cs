using SellingBags.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Design;
using System.Linq;
using System.Web;

namespace SellingBags.Areas.Admin.Models.ViewModel
{
    public class ProductVM
    {
        [Key]
        public string ID_Product { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
        public string Size { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int Discount { get; set; }
        public Product Product { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public IEnumerable<Product> ProductsAll { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }
        public IEnumerable<Product> ProductsByType { get; set; }
        public IEnumerable<Product> ProductsByBrand { get; set; }
        public IEnumerable<Product> ProductsByCategory { get; set; }

    }
}