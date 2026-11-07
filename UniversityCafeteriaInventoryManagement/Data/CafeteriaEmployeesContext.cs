using Microsoft.EntityFrameworkCore;
using UniversityCafeteriaInventoryManagement.Models.CodeFirst;

namespace UniversityCafeteriaInventoryManagement.Data;

public class CafeteriaEmployeesContext : DbContext
{
    public CafeteriaEmployeesContext(DbContextOptions<CafeteriaEmployeesContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(254);
            entity.Property(e => e.Phone).HasMaxLength(30);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Price).HasPrecision(10, 2);
        });

        modelBuilder.Entity<PurchaseOrder>()
            .Property(e => e.Status).HasMaxLength(30);

        modelBuilder.Entity<PurchaseOrderItem>()
            .Property(e => e.UnitPrice).HasPrecision(10, 2);
    }
}
