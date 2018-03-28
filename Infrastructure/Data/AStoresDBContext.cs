using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<AStoresDBContext>
    {
        public AStoresDBContext CreateDbContext(string[] args)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<AStoresDBContext>();
            ////      optionsBuilder.UseSqlite("Data Source=blog.db");
            ////      optionsBuilder.UseSqlServer(@"Server=SUSANYANG\SQLEXPRESS; Initial Catalog = TestDBSecond; Persist Security Info=True;User ID = sa; Password=SPX123!@#");
            //optionsBuilder.UseSqlServer(@"Server=SUSANYANG\SQLEXPRESS; Initial Catalog = TestDBSixth; Trusted_Connection=True; ");

            return new AStoresDBContext();
            //            return new AStoresDBContext(optionsBuilder.Options);
        }
    }
    public class AStoresDBContext: DbContext
  {
        //public AStoresDBContext(DbContextOptions<AStoresDBContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["AStoresDBContext"].ConnectionString);

 //           optionsBuilder.UseSqlServer(@"Server=SUSANYANG\SQLEXPRESS; Initial Catalog = TestDBSixth; Trusted_Connection=True;");
        }

        public DbSet<CatalogType> CategoryTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductChanges> ProductChangeds { get; set; }
        public DbSet<Customer> BizTenants { get; set; }
        public DbSet<OrderItemStatus> OrderItemStatuses { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CatalogType>(ConfigureCategoryType);
            builder.Entity<Product>(ConfigureProduct);
            builder.Entity<SalesOrder>(ConfigureSalesOrder);
            builder.Entity<OrderItem>(ConfigureOrderItem);
            builder.Entity<ProductChanges>(ConfigureProductChanged);
            builder.Entity<Customer>(ConfigureCustomer);
            builder.Entity<OrderItemStatus>(ConfigureOrderItemStatus);
            builder.Entity<PaymentMethod>(ConfigurePaymentMethod);
            builder.Entity<OrderStatus>(ConfigureOrderStatus);
        }


        #region configuration
        private void ConfigureOrderStatus(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.ToTable("FM_OrderStatus");
            builder.HasKey(c => c.F_Id);
            builder.Property(o => o.F_Id).ValueGeneratedOnAdd().HasDefaultValueSql("newid()");

            builder.Property(c => c.F_OrderStatus).IsRequired().HasMaxLength(30);

            builder.Property(c => c.F_LastModifiedDate).HasDefaultValueSql("GetUtcDate()");
            builder.Property(c => c.RowVersion).IsRowVersion().IsConcurrencyToken();
        }

        private void ConfigurePaymentMethod(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("FM_Paymentmethods");
            builder.HasKey(c => c.F_Id);
            builder.Property(o => o.F_Id).ValueGeneratedOnAdd().HasDefaultValueSql("newid()");

            builder.Property(c => c.F_PaymentName).IsRequired().HasMaxLength(30);

            builder.Property(c => c.F_LastModifiedDate).HasDefaultValueSql("GetUtcDate()");
            builder.Property(c => c.RowVersion).IsRowVersion().IsConcurrencyToken();
        }

        private void ConfigureOrderItemStatus(EntityTypeBuilder<OrderItemStatus> builder)
        {
            builder.ToTable("FM_OrderItemsStatus");
            builder.HasKey(c => c.F_Id);
            builder.Property(o => o.F_Id).ValueGeneratedOnAdd().HasDefaultValueSql("newid()");

            builder.Property(c => c.F_OrderItemStatus).IsRequired().HasMaxLength(30);

            builder.Property(c => c.F_LastModifiedDate).HasDefaultValueSql("GetUtcDate()");
            builder.Property(c => c.RowVersion).IsRowVersion().IsConcurrencyToken();
        }

        private void ConfigureCustomer(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("FM_Customer");
            builder.HasKey(c => c.F_Id);
            builder.Property(o => o.F_Id).ValueGeneratedOnAdd().HasDefaultValueSql("newid()");

            builder.Property(c => c.F_FirstName).IsRequired();
            builder.Property(c => c.F_LastName).IsRequired();
            builder.Property(c => c.F_Account).HasMaxLength(50);
            builder.Property(c => c.F_Address).HasMaxLength(100);
            builder.Property(c => c.F_MobilePhone).HasMaxLength(15);

            builder.Property(c => c.F_LastModifiedDate).HasDefaultValueSql("GetUtcDate()");
            builder.Property(c => c.RowVersion).IsRowVersion().IsConcurrencyToken();
        }
        private void ConfigureCategoryType(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("FM_ProductCarategory");
            builder.HasKey(c => c.F_Id);
            builder.Property(o => o.F_Id).ValueGeneratedOnAdd().HasDefaultValueSql("newid()");

            builder.Property(c => c.F_FullName).IsRequired().HasMaxLength(50);

            builder.Property(c => c.F_LastModifiedDate).HasDefaultValueSql("GetUtcDate()");
            builder.Property(c => c.RowVersion).IsRowVersion().IsConcurrencyToken();
        }

        private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("FM_Products");
            builder.HasKey(p => p.F_Id);
            builder.Property(o => o.F_Id).ValueGeneratedOnAdd().HasDefaultValueSql("newid()");

            builder.Property(p => p.F_FullName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.F_EnCode).HasMaxLength(8).IsRequired();
            builder.Property(p => p.F_ImageUrl1).HasMaxLength(100);

            builder.HasOne(p => p.CatalogType)
              .WithMany(c => c.Products)
              .HasForeignKey(c => c.CatalogId);

            builder.Property(c => c.F_LastModifiedDate).HasDefaultValueSql("GetUtcDate()");
            builder.Property(c => c.RowVersion).IsRowVersion().IsConcurrencyToken();
        }

        private void ConfigureProductChanged(EntityTypeBuilder<ProductChanges> builder)
        {
            builder.ToTable("FM_ProductChanges");
            builder.HasKey(p => p.F_Id);
            builder.Property(o => o.F_Id).ValueGeneratedOnAdd().HasDefaultValueSql("newid()");

            builder.Property(p => p.F_NewPrice).IsRequired();

            builder.HasOne(p => p.Product)
              .WithMany(p => p.PriceChanges)
              .HasForeignKey(p => p.F_ProductId);

            builder.Property(c => c.F_LastModifiedDate).HasDefaultValueSql("GetUtcDate()");
            builder.Property(c => c.RowVersion).IsRowVersion().IsConcurrencyToken();
        }

        private void ConfigureSalesOrder(EntityTypeBuilder<SalesOrder> builder)
        {
            builder.ToTable("FM_SalesOrder");
            builder.HasKey(p => p.F_Id);
            builder.Property(o => o.F_Id).ValueGeneratedOnAdd().HasDefaultValueSql("newid()");
            builder.Property(o => o.F_TotalDue).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("(isnull(([F_SubTotal]+[F_TaxAmt]),(0.0)))");
            builder.Property(o => o.F_OrderNumber).IsRequired();
            builder.Property(o => o.F_OrderDate).IsRequired();
            builder.Property(o => o.F_SubTotal).IsRequired();
            builder.Property(o => o.F_TotalDue).IsRequired();

            // create a id=0 for non customer
            builder.HasOne(p => p.Customer)
              .WithMany(c => c.SalesOrders)
              .HasForeignKey(p => p.CustomerId);
            builder.HasOne(p => p.PaymentMethod)
              .WithMany(p => p.SalesOrders)
              .HasForeignKey(p => p.PaymentMethodId);
            builder.HasOne(p => p.OrderStatus)
              .WithMany(o => o.SalesOrders)
              .HasForeignKey(p => p.OrderStatusId);

            builder.Property(c => c.F_LastModifiedDate).HasDefaultValueSql("GetUtcDate()");
            builder.Property(c => c.RowVersion).IsRowVersion().IsConcurrencyToken();
        }

        private void ConfigureOrderItem(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("FM_OrderItem");
            builder.HasKey(p => p.F_Id);
            builder.Property(o => o.F_Id).ValueGeneratedOnAdd().HasDefaultValueSql("newid()");
            builder.Property(o => o.F_LineTotal)
                .ValueGeneratedOnAddOrUpdate()
               .HasComputedColumnSql("(isnull(([F_Price]*[F_Quantity]),(0.0)))");


            builder.Property(o => o.F_Price).IsRequired();
            builder.Property(o => o.F_Quantity).IsRequired();

            builder.HasOne(o => o.F_OrderItemStatus)
              .WithMany(o => o.OrderItems)
              .HasForeignKey(o => o.OrderItemStatusId);

            builder.HasOne(o => o.Product)
              .WithMany(p => p.OrderItems)
              .HasForeignKey(o => o.F_ProductId);

            builder.HasOne(o => o.SalesOrder)
              .WithMany(s => s.OrderItems)
              .HasForeignKey(o => o.F_SalesOrderId);

            builder.Property(c => c.F_LastModifiedDate).HasDefaultValueSql("GetUtcDate()");
            builder.Property(c => c.RowVersion).IsRowVersion().IsConcurrencyToken();
        }
    #endregion
  }
}
