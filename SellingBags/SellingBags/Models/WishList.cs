//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SellingBags.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WishList
    {
        public string ID_WishList { get; set; }
        public string ID_Product { get; set; }
        public string ID_Account { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Account Account { get; set; }
    }
}