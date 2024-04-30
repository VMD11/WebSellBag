using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace SellingBags.Common
{
    public static class Converts
    {
        public static string convertVND(Decimal? value)
        {
            return string.Format(new CultureInfo("vi-VN"), "{0:C0}", value);
        }

        public static string convertDate(DateTime? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                return string.Empty;
            }
        }

        public static string convertDateTime(DateTime? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToString("dd/MM/yyyy HH:mm:ss");
            }else { return string.Empty; }
        }
    }
}