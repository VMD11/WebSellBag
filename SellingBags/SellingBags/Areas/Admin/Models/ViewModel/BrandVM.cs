using SellingBags.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SellingBags.Areas.Admin.Models.ViewModel
{
    public class BrandVM
    {
        [Key]
        public string ID_Brand { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên thương hiệu")]
        public string Name { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public Brand Brand { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}