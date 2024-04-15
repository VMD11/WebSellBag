using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace SellingBags.Converter
{
    public static class ConvertVND
    {
        public static string convertVND(Decimal? value)
        {
            return string.Format(new CultureInfo("vi-VN"), "{0:C0}", value);
        }
    }
}