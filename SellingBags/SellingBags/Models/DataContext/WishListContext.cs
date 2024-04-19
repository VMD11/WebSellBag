using SellingBags.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.DataContext
{
    public class WishListContext
    {
        private SellingBagsEntities db;
        private List<Product> WishList;
        public WishListContext()
        {
            db = new SellingBagsEntities();
            WishList = new List<Product>();
        }

        public IEnumerable<Product> GetWishLists(string ID_Account)
        {
            if (ID_Account == null)
                return null;
            var wishLists = db.WishLists.Where(w => w.ID_Account ==  ID_Account);
            ProductContext productContext = new ProductContext();
            foreach(var wishList in wishLists)
            {
                WishList.Add(productContext.GetProduct(wishList.ID_Product));
            }
            return WishList;
        }

        public void AddToWishList(string ID_Account ,string ID_Product)
        {
            if (!IsWishListed(ID_Account,ID_Product))
            {
                db.WishLists.Add(new WishList { ID_WishList = GenarateRandomID.Execute(), ID_Account = ID_Account, ID_Product = ID_Product });
                db.SaveChanges();
            }
        }
        public void RemoveToWishList(string ID_Account, string ID_Product)
        {
            var item = db.WishLists.FirstOrDefault(w => w.ID_Account == ID_Account && w.ID_Product == ID_Product);
            if (item != null)
            {
                db.WishLists.Remove(item);
                db.SaveChanges();
            }
        }
        public bool IsWishListed(string ID_Account, string ID_Product)
        {
            var result = db.WishLists.FirstOrDefault(r => r.ID_Account == ID_Account && r.ID_Product == ID_Product);
            return result != null;
        }
    }
}