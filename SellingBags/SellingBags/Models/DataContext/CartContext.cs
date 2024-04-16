using SellingBags.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.DataContext
{
    public class CartContext
    {
        private SellingBagsEntities db;
        private List<Cart> CartList = new List<Cart>();
        public CartContext()
        {
            db = new SellingBagsEntities();
        }

        public List<Cart> GetList()
        {
            return CartList;
        }

        public void AddProduct(string ID_Product, int Quantity)
        {
            var newProduct = Product(ID_Product);
            if (newProduct == null)
            {
                return;
            }

            var existProduct = CartList.FirstOrDefault(p => p.Product.ID_Product == newProduct.ID_Product);
            if (existProduct != null) 
            {
                existProduct.Quantity += Quantity;
            }
            else
            {
                double? Discount = 0;
                CartList.Add(new Cart { Product = newProduct, Quantity = Quantity, Discount = Discount});
            }
        }

        public void UpdateProduct(string ID_Product, int Quantity)
        {
            var newProduct = Product(ID_Product);
            if (newProduct == null)
            {
                return;
            }

            var existProduct = CartList.FirstOrDefault(p => p.Product.ID_Product == newProduct.ID_Product);
            if (existProduct != null)
            {
                existProduct.Quantity = Quantity;
            }
        }
        public void DeleteProduct(string ID_Product)
        {
            var newProduct = Product(ID_Product);
            if (newProduct == null)
            {
                return;
            }

            var existProduct = CartList.FirstOrDefault(p => p.Product.ID_Product == newProduct.ID_Product);
            if (existProduct != null)
            {
                CartList.Remove(existProduct);
            }
        }
        
        public decimal TotalMoney()
        {
            return (decimal) CartList.Sum(t => ((float)t.Product.Price*(float)(100-t.Discount)/100)*t.Quantity);
        }

        private Product Product(string ID_Product)
        {
            return db.Products.FirstOrDefault(p => p.ID_Product == ID_Product);
        }
    }
}