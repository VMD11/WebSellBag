using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Areas.Admin.Models.ViewModel
{
    public class DashboardVM
    {
        public int ProductsCount { get; set; }
        public int TypesCount { get; set; }
        public int BrandsCount { get; set; }
        public int OrdersCount { get; set; }
        public decimal DaylyRevenue { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public decimal QuarterlyRevenue { get; set; }
        public decimal YearlyRevenue { get; set; }
        public OrderVM Order { get; set; }
    }
}