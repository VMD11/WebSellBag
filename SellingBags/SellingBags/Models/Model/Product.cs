namespace SellingBags.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Discounts = new HashSet<Discount>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [StringLength(10)]
        public string ID_Product { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Size { get; set; }

        [StringLength(30)]
        public string Color { get; set; }

        public string ImagURL { get; set; }

        public decimal? Price { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Required]
        [StringLength(10)]
        public string ID_Type { get; set; }

        [Required]
        [StringLength(10)]
        public string ID_Brand { get; set; }

        public virtual Brand Brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Discount> Discounts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}
