using SellingBags.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.DataContext
{
    public class CheckoutContext
    {
        private SellingBagsEntities db = null;
        private List<PaymentMethod> paymentMethods = new List<PaymentMethod>();
        private List<ShippingMethod> shippingCost = new List<ShippingMethod>();
        private OrderContext orderContext = new OrderContext();
        public CheckoutContext()
        {
            db = new SellingBagsEntities();
            FakeData();
        }
        private void FakeData()
        {
            paymentMethods.Add(new PaymentMethod("Ví MOMO", "thanh-toan-bang-vi-momo.png"));
            paymentMethods.Add(new PaymentMethod("Ví ZALOPAY", "thanh-toan-bang-vi-zalopay.png"));
            paymentMethods.Add(new PaymentMethod("Ví VNPAY", "thanh-toan-bang-vi-vnpay.png"));
            paymentMethods.Add(new PaymentMethod("Ví SHOPEEPAY", "thanh-toan-bang-vi-shopeepay.png"));
            shippingCost.Add(new ShippingMethod("J&T Express", "từ 5-7 ngày", 6, 18000));
            shippingCost.Add(new ShippingMethod("GHTK", "từ 3-4 ngày", 4, 25000));
            shippingCost.Add(new ShippingMethod("Ninja Van", "từ 2-3 ngày", 3, 36000));
            shippingCost.Add(new ShippingMethod("GrabEpress", "trong ngày", 0, 52000));
        }

        public IEnumerable<PaymentMethod> GetPaymentMethods()
        {
            return paymentMethods;
        }
        public PaymentMethod GetPaymentMethod(string Name)
        {
            return paymentMethods.FirstOrDefault(m => m.Name == Name);
        }
        public IEnumerable<ShippingMethod> GetShippingCost() 
        {  
            return shippingCost; 
        }
        public ShippingMethod GetShippingMethod(string Name)
        {
            return shippingCost.FirstOrDefault(m => m.Name == Name);
        }
        public IEnumerable<Address> GetAddresses(string ID_Account)
        {
            
            var ID_Customer = orderContext.GetCustomer(ID_Account).ID_Customer;
            return db.Addresses.Where(a => a.ID_Customer == ID_Customer);

        }
    }
}