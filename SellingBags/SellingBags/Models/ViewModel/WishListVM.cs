using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.ViewModel
{
    public class WishListVM
    {
        public Account Account { get; set; }
        public Product Product { get; set; }
        public bool IsWishListed { get; set; }
        public IEnumerable<Product> WishLists { get; set; }
    }
}