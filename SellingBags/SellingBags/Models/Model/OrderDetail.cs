namespace SellingBags.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [StringLength(10)]
        public string ID_OrderDetail { get; set; }

        [Required]
        [StringLength(10)]
        public string ID_Order { get; set; }

        [Required]
        [StringLength(10)]
        public string ID_Product { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
