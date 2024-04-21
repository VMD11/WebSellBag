﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SellingBags.Models.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Thông tin còn trống, vui lòng nhập đầy đủ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu còng trống, vui lòng nhập đầy đủ")]
        public string Password { get; set; }

        
    }
}