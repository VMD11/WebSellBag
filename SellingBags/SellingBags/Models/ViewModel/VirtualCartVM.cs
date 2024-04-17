using SellingBags.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.ViewModel
{
    public class VirtualCartVM
    {
        public string ID_Account { get; set; }
        public VirtualCart cart { get; set; }
    }
}