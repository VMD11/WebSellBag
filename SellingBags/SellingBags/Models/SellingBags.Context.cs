﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SellingBagsEntities : DbContext
    {
        public SellingBagsEntities()
            : base("name=SellingBagsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
    
        public virtual ObjectResult<spLoadAllBrand_Result> spLoadAllBrand()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spLoadAllBrand_Result>("spLoadAllBrand");
        }
    
        public virtual ObjectResult<spProductsByType_Result> spProductsByType(string iD_Category)
        {
            var iD_CategoryParameter = iD_Category != null ?
                new ObjectParameter("ID_Category", iD_Category) :
                new ObjectParameter("ID_Category", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spProductsByType_Result>("spProductsByType", iD_CategoryParameter);
        }
    
        public virtual ObjectResult<string> spLastCustomer()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("spLastCustomer");
        }
    }
}
