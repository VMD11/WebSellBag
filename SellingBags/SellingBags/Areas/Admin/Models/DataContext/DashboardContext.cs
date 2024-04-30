using SellingBags.Areas.Admin.Models.ViewModel;
using SellingBags.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace SellingBags.Areas.Admin.Models.DataContext
{
    public class DashboardContext
    {
        private SellingBagsEntities db = null;
        private OrderContext orderContext = null;
        private OrderVM orderVM = null;
        public DashboardContext()
        {
            db = new SellingBagsEntities();
            orderVM = new OrderVM();
            orderContext = new OrderContext();
        }

        public decimal GetMonthlyRevenue()
        {
            return db.Orders.Where(o => o.OrderDate.Value.Month == DateTime.Now.Month && o.Status == 1).Sum(o => o.TotalMoney.Value);
        }
        public decimal GetYearlyRevenue()
        {
            return db.Orders.Where(o => o.OrderDate.Value.Year == DateTime.Now.Year && o.Status == 1).Sum(o => o.TotalMoney.Value);
        }

        private decimal RevenuePerMonth(int month)
        {
            var revenue = db.Orders.Where(o => o.OrderDate.HasValue && o.OrderDate.Value.Month == month && o.Status == 0);
            return revenue.Sum(o => o.TotalMoney.Value) == null  ? 0 : revenue.Sum(o => o.TotalMoney.Value);

        }

        public List<decimal> GetRevenuePerMonth()
        {
            var List = new List<decimal>();
            for(int i = 1; i <= 12; i++)
            {
                List.Add(RevenuePerMonth(i));
            }
            return List;
        }
    }
}