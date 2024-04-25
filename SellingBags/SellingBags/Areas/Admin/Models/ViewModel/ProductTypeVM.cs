using SellingBags.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SellingBags.Areas.Admin.Models.ViewModel
{
    public class ProductTypeVM
    {
        [Key]
        public string ID_Type { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên loại")]
        public string Name { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public string Category { get; set; }
        public ProductType ProductType { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}