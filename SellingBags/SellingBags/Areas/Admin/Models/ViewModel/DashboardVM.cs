using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Areas.Admin.Models.ViewModel
{
    public class DashboardVM
    {
        public decimal DaylyRevenue { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public decimal QuarterlyRevenue { get; set; }
        public decimal YearlyRevenue { get; set; }
        public OrderVM Order { get; set; }
    }
}