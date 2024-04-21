using SellingBags.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.DataContext
{
    public class CheckoutContext
    {
        private List<PaymentMethod> paymentMethods = new List<PaymentMethod>();
        private List<ShippingMethod> shippingCost = new List<ShippingMethod>();

        public CheckoutContext()
        {
            FakeData();
        }
        private void FakeData()
        {
            paymentMethods.Add(new PaymentMethod("Ví MOMO", "thanh-toan-bang-vi-momo.png"));
            paymentMethods.Add(new PaymentMethod("Ví ZALOPAY", "thanh-toan-bang-vi-zalopay.png"));
            paymentMethods.Add(new PaymentMethod("Ví VNPAY", "thanh-toan-bang-vi-vnpay.png"));
            paymentMethods.Add(new PaymentMethod("Ví SHOPEEPAY", "thanh-toan-bang-vi-shopeepay.png"));
            shippingCost.Add(new ShippingMethod("J&T Express", "từ 5-7 ngày", 18000));
            shippingCost.Add(new ShippingMethod("GHTK", "từ 3-4 ngày", 25000));
            shippingCost.Add(new ShippingMethod("Ninja Van", "từ 2-3 ngày", 36000));
            shippingCost.Add(new ShippingMethod("GrabEpress", "trong ngày", 52000));
        }

        public IEnumerable<PaymentMethod> GetPaymentMethods()
        {
            return paymentMethods;
        }
        public IEnumerable<ShippingMethod> GetShippingCost() 
        {  
            return shippingCost; 
        }
    }
}