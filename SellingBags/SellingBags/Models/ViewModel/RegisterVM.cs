using SellingBags.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SellingBags.Models.ViewModel
{
    public class RegisterVM
    {
        public string ID_Account { get; set; }

        [Required(ErrorMessage = "Thông tin còn trống, vui lòng nhập đầy đủ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Thông tin còn trống, vui lòng nhập đầy đủ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Thông tin còn trống, vui lòng nhập đầy đủ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Thông tin còn trống, vui lòng nhập đầy đủ")]
        public string Password { get; set; }
    }
}