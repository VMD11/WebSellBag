namespace SellingBags.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Discount")]
    public partial class Discount
    {
        [Key]
        [StringLength(10)]
        public string ID_Discount { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public double? Percents { get; set; }

        [Required]
        [StringLength(10)]
        public string ID_Product { get; set; }

        public virtual Product Product { get; set; }
    }
}
