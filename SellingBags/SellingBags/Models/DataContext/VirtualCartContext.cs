using SellingBags.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.DataContext
{
    public class VirtualCartContext
    {
        private SellingBagsEntities db;
        private List<VirtualCart> VirtualCartList = new List<VirtualCart>();
        public VirtualCartContext()
        {
            db = new SellingBagsEntities();
        }

        public List<VirtualCart> GetList()
        {
            return VirtualCartList;
        }
        public bool CheckQuantity(string ID_Product, int Quantity)
        {
            return GetProductByID(ID_Product).Quantity > Quantity;
        }

        public void AddProduct(string ID_Product, int Quantity)
        {
            var newProduct = GetProductByID(ID_Product);
            if (newProduct == null)
            {
                return;
            }

            var existProduct = VirtualCartList.FirstOrDefault(p => p.Product.ID_Product == newProduct.ID_Product);
            if (existProduct != null) 
            {
                existProduct.Quantity += Quantity;
            }
            else
            {
                double? Discount = 0;
                VirtualCartList.Add(new VirtualCart { Product = newProduct, Quantity = Quantity, Discount = Discount});
            }
        }

        public void UpdateProduct(string ID_Product, int Quantity)
        {
            var newProduct = GetProductByID(ID_Product);
            if (newProduct == null)
            {
                return;
            }

            var existProduct = VirtualCartList.FirstOrDefault(p => p.Product.ID_Product == newProduct.ID_Product);
            if (existProduct != null)
            {
                existProduct.Quantity = Quantity;
            }
        }
        public void DeleteProduct(string ID_Product)
        {
            var newProduct = GetProductByID(ID_Product);
            if (newProduct == null)
            {
                return;
            }

            var existProduct = VirtualCartList.FirstOrDefault(p => p.Product.ID_Product == newProduct.ID_Product);
            if (existProduct != null)
            {
                VirtualCartList.Remove(existProduct);
            }
        }
        
        public decimal TotalMoney()
        {
            return (decimal) VirtualCartList.Sum(t => ((float)t.Product.Price*(float)(100-t.Discount)/100)*t.Quantity);
        }

        public int TotaQuantity()
        {
            int result = 0;
            foreach(var item in VirtualCartList)
            {
                result += item.Quantity;
            }
            return result;
        }

        private Product GetProductByID(string ID_Product)
        {
            return db.Products.FirstOrDefault(p => p.ID_Product == ID_Product);
        }
    }
}