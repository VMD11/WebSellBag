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
        private SellingBagsEntities db = new SellingBagsEntities();
        
        public int GetProductsCount()
        {
            return db.Products.Count();
        }
        public int GetTypesCount()
        {
            return db.ProductTypes.Count();
        }
        public int GetBrandsCount()
        {
            return db.Brands.Count();
        }
        public int GetOrdersCount()
        {
            return db.Orders.Count();
        }

        public decimal GetMonthlyRevenue()
        {
            var revenue = db.spMonthlyRevenue(DateTime.Now.Month).Last();
            return revenue.HasValue ? revenue.Value : 0;
        }
        public decimal GetYearlyRevenue()
        {
            var revenue = db.spYearlyRevenue(DateTime.Now.Year).Last();
            return revenue.HasValue ? revenue.Value : 0;
        }

        public decimal GetDaylyRevenue()
        {
            var revenue = db.spDaylyRevenue(DateTime.Now).Last();
            return revenue.HasValue ? revenue.Value : 0;
        }

        private decimal RevenuePerMonth(int month)
        {
            var revenue = db.spMonthlyRevenue(month).Last();
            return revenue.HasValue ? revenue.Value : 0;

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