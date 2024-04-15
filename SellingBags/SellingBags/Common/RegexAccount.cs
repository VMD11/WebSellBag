using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Common
{
    public class RegexAccount
    {
        public static string phoneRegex { get; } = @"^\d{10,11}$";
                
        public static string emailRegex { get; } = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public static string passwordRegex { get; } = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";


    }
}