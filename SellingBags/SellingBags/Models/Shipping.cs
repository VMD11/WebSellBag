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
    
    public partial class Shipping
    {
        public int ID_Shipping { get; set; }
        public string Name { get; set; }
        public string DeliTime { get; set; }
        public Nullable<int> DeliDate { get; set; }
        public Nullable<decimal> Cost { get; set; }
    }
}
