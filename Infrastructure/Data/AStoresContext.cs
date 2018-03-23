using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ApplicationCore.Entities;

namespace Infrastructure.Data
{
  public class AStoresContext: DbContext
  {
    public AStoresContext(DbContextOptions<AStoresContext> options): base(options)
    {

    }

    public DbSet<FM_ProductCarategory> CategoryTypes { get; set; }
    public DbSet<FM_Product> Products { get; set; }
    public DbSet<SalesOrder> SalesOrders { get; set; }
    public DbSet<FM_OrderItem> OrderItems { get; set; }
    public DbSet<FM_ProductChanges> ProductChangeds { get; set; }
    public DbSet<FM_BizTenant> BizTenants { get; set; }
    public DbSet<UnitType> UnitTypes { get; set; }
    public DbSet<LocalCatalogType> LocalCatalogTypes { get; set; }
    public DbSet<OrderItemStatus> OrderItemStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<FM_ProductCarategory>(ConfigureCategoryType);
      builder.Entity<FM_Product>(ConfigureProduct);
      builder.Entity<SalesOrder>(ConfigureSalesOrder);
      builder.Entity<FM_OrderItem>(ConfigureOrderItem);
      builder.Entity<FM_ProductChanges>(ConfigureProductChanged);
    }

    #region configuration
    private void ConfigureCategoryType(EntityTypeBuilder<FM_ProductCarategory> builder)
    {
      builder.ToTable("CategoryType");
      builder.HasKey(c => c.F_Id);

      builder.Property(c => c.F_Id).IsRequired();
      builder.Property(c => c.F_FullName).IsRequired().HasMaxLength(50);

      builder.Property(c => c.RowVersion).IsRowVersion();
    }

    private void ConfigureProduct(EntityTypeBuilder<FM_Product> builder)
    {
      builder.ToTable("Product");
      builder.HasKey(p => p.F_Id);

      builder.Property(p => p.F_Id).IsRequired();
      builder.Property(p => p.F_FullName).IsRequired().HasMaxLength(50);
      builder.Property(p => p.F_EnCode).HasMaxLength(8);
      builder.Property(p => p.F_ImageUrl1).HasMaxLength(100);
      builder.Property(p => p.F_Unit).IsRequired();

      builder.HasOne(p => p.CatalogType)
        .WithMany()
        .HasForeignKey(c => c.CatalogId);

      builder.Property(c => c.RowVersion).IsRowVersion();
    }

    private void ConfigureProductChanged(EntityTypeBuilder<FM_ProductChanges> builder)
    {
      builder.ToTable("ProductChanged");
      builder.HasKey(p => p.F_Id);

      builder.Property(p => p.F_Id).IsRequired();
      builder.Property(p => p.F_NewPrice).IsRequired();

            builder.HasOne(p => p.Product)
              .WithMany()
              .HasForeignKey(p => p.F_ProductId);
      builder.Property(c => c.RowVersion).IsRowVersion();
    }

    private void ConfigureSalesOrder(EntityTypeBuilder<SalesOrder> builder)
    {
      builder.ToTable("SalesOrder");
      builder.HasKey(p => p.F_Id);

      builder.Property(o => o.F_Id).IsRequired();
      builder.Property(o => o.F_SubTotal).IsRequired();
      builder.Property(o => o.F_OrderDate).IsRequired();
      builder.Property(o => o.OrderItems).IsRequired();
      builder.Property(o => o.F_RefundStatus).IsRequired();
      builder.Property(o => o.F_PaymentTypeId).IsRequired();

      builder.Property(c => c.RowVersion).IsRowVersion();
    }

    private void ConfigureOrderItem(EntityTypeBuilder<FM_OrderItem> builder)
    {
      builder.ToTable("OrderItem");
      builder.HasKey(p => p.F_Id);

      builder.Property(o => o.F_Id).IsRequired();
      builder.Property(o => o.F_Price).IsRequired();
      builder.Property(o => o.F_Quantity).IsRequired();
      builder.Property(o => o.Status).IsRequired();

      builder.HasOne(p => p.Product)
        .WithMany()
        .HasForeignKey(p => p.F_ProductId);
      builder.HasOne(o => o.SalesOrder)
        .WithMany()
        .HasForeignKey(s => s.F_OrderId);
      
      builder.Property(c => c.RowVersion).IsRowVersion();
    }
    #endregion
  }
}
