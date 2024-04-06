using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SellingBags.Models.Model
{
    public partial class SellingBagsDB : DbContext
    {
        public SellingBagsDB()
            : base("name=SellingBagsDB")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.ID_Account)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.ID_Role)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Brand>()
                .Property(e => e.ID_Brand)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Brand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ID_Customer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.ID_Account)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.ID_Discount)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.ID_Product)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ID_Order)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ID_Customer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.ID_OrderDetail)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.ID_Order)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.ID_Product)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ID_Product)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Size)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Color)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ID_Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ID_Brand)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Discounts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductType>()
                .Property(e => e.ID_Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ProductType>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.ProductType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.ID_Role)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);
        }
    }
}
