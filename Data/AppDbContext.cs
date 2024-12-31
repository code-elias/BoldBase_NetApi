using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RepositoryNetAPI.Models;

namespace RepositoryNetAPI.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    #region DbSets
    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<AuditLog> AuditLogs { get; set; }
    public virtual DbSet<Bundle> Bundles { get; set; }
    public virtual DbSet<ContactInformation> ContactInformations { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<CustomerProduct> CustomerProducts { get; set; }
    public virtual DbSet<CustomerType> CustomerTypes { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<DepartmentLocation> DepartmentLocations { get; set; }
    public virtual DbSet<Inventory> Inventories { get; set; }
    public virtual DbSet<InventoryWarehouse> InventoryWarehouses { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderLine> OrderLines { get; set; }
    public virtual DbSet<Permission> Permissions { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductCategory> ProductCategories { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<RolePermission> RolePermissions { get; set; }
    public virtual DbSet<Seller> Sellers { get; set; }
    public virtual DbSet<SellerProduct> SellerProducts { get; set; }
    public virtual DbSet<SellerType> SellerTypes { get; set; }
    public virtual DbSet<Subscription> Subscriptions { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserRole> UserRoles { get; set; }
    public virtual DbSet<Warehouse> Warehouses { get; set; }
    public virtual DbSet<Warranty> Warranties { get; set; }
    #endregion DbSets

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlite("Data Source=Database\\BoldBase.db"); // Not needed with the connection being in Program.cs

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasIndex(e => e.CountryCode, "IDX_Addresses_CountryCode");

            entity.Property(e => e.Address1).HasColumnName("Address");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasIndex(e => e.ChangedBy, "IDX_AuditLogs_ChangedBy");

            entity.HasIndex(e => e.RecordId, "IDX_AuditLogs_RecordId");

            entity.HasIndex(e => e.TableName, "IDX_AuditLogs_TableName");

            entity.Property(e => e.ChangedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.ChangedByNavigation).WithMany(p => p.AuditLogs).HasForeignKey(d => d.ChangedBy);
        });

        modelBuilder.Entity<Bundle>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_Bundles_Name").IsUnique();

            entity.HasIndex(e => e.Name, "IDX_Bundles_Name");

            entity.Property(e => e.Price)
                .HasDefaultValueSql("0")
                .HasColumnType("NUMERIC");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasIndex(e => e.UserName, "IX_Customers_UserName").IsUnique();

            entity.HasIndex(e => e.AddressId, "IDX_Customers_AddressId");

            entity.HasIndex(e => e.ContactInformationId, "IDX_Customers_ContactInformationId");

            entity.HasIndex(e => e.CustomerTypeId, "IDX_Customers_CustomerTypeId");

            entity.HasIndex(e => e.UserName, "IDX_Customers_UserName");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Address).WithMany(p => p.Customers).HasForeignKey(d => d.AddressId);

            entity.HasOne(d => d.ContactInformation).WithMany(p => p.Customers).HasForeignKey(d => d.ContactInformationId);

            entity.HasOne(d => d.CustomerType).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CustomerProduct>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IDX_CustomerProducts_CustomerId");

            entity.HasIndex(e => e.ProductId, "IDX_CustomerProducts_ProductId");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerProducts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.CustomerProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CustomerType>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_CustomerTypes_Name").IsUnique();

            entity.HasIndex(e => e.Name, "IDX_CustomerTypes_Name");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_Departments_Name").IsUnique();

            entity.HasIndex(e => e.Name, "IDX_Departments_Name");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<DepartmentLocation>(entity =>
        {
            entity.HasIndex(e => e.DepartmentId, "IDX_DepartmentLocations_DepartmentId");

            entity.HasIndex(e => e.LocationId, "IDX_DepartmentLocations_LocationId");

            entity.HasOne(d => d.Department).WithMany(p => p.DepartmentLocations).HasForeignKey(d => d.DepartmentId);

            entity.HasOne(d => d.Location).WithMany(p => p.DepartmentLocations).HasForeignKey(d => d.LocationId);
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasIndex(e => e.DefaultWarehouseId, "IDX_Inventories_DefaultWarehouseId");

            entity.HasIndex(e => e.ProductId, "IDX_Inventories_ProductId");

            entity.Property(e => e.QuantityInStock).HasColumnType("NUMERIC");
            entity.Property(e => e.ReorderLevel).HasColumnType("NUMERIC");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<InventoryWarehouse>(entity =>
        {
            entity.HasIndex(e => e.InventoryId, "IDX_InventoryWarehouses_InventoryId");

            entity.HasIndex(e => e.WarehouseId, "IDX_InventoryWarehouses_WarehouseId");

            entity.HasOne(d => d.Inventory).WithMany(p => p.InventoryWarehouses).HasForeignKey(d => d.InventoryId);

            entity.HasOne(d => d.Warehouse).WithMany(p => p.InventoryWarehouses).HasForeignKey(d => d.WarehouseId);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasIndex(e => e.AddressId, "IDX_Locations_AddressId");

            entity.HasIndex(e => e.Code, "IDX_Locations_Code");

            entity.HasOne(d => d.Address).WithMany(p => p.Locations).HasForeignKey(d => d.AddressId);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.OrderNumber, "IX_Orders_OrderNumber").IsUnique();

            entity.HasIndex(e => e.CustomerId, "IDX_Orders_CustomerId");

            entity.HasIndex(e => e.OrderNumber, "IDX_Orders_OrderNumber");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Status).HasDefaultValue("Pending");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<OrderLine>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "IDX_OrderLines_OrderId");

            entity.HasIndex(e => e.ProductId, "IDX_OrderLines_ProductId");

            entity.Property(e => e.Currency).HasDefaultValue("EUR");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("1")
                .HasColumnType("NUMERIC");
            entity.Property(e => e.UnitPrice)
                .HasDefaultValueSql("0")
                .HasColumnType("NUMERIC");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderLines).HasForeignKey(d => d.OrderId);

            entity.HasOne(d => d.Product).WithMany(p => p.OrderLines).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_Permissions_Name").IsUnique();

            entity.HasIndex(e => e.Name, "IDX_Permissions_Name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.Code, "IX_Products_Code").IsUnique();

            entity.HasIndex(e => e.Name, "IX_Products_Name").IsUnique();

            entity.HasIndex(e => e.Code, "IDX_Products_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_Products_CreatedBy");

            entity.HasIndex(e => e.ModifiedBy, "IDX_Products_ModifiedBy");

            entity.HasIndex(e => e.Name, "IDX_Products_Name");

            entity.HasIndex(e => e.ProductCategoryId, "IDX_Products_ProductCategoryId");

            entity.HasIndex(e => e.SubscriptionId, "IDX_Products_SubscriptionId");

            entity.HasIndex(e => e.WarrantyId, "IDX_Products_WarrantyId");

            entity.Property(e => e.BundleAmount).HasDefaultValue(1);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IsActive).HasDefaultValue(1);
            entity.Property(e => e.IsSoldProduct).HasDefaultValue(1);
            entity.Property(e => e.Price)
                .HasDefaultValueSql("0")
                .HasColumnType("NUMERIC");
            entity.Property(e => e.Vat).HasColumnName("VAT");

            entity.HasOne(d => d.Bundle).WithMany(p => p.Products).HasForeignKey(d => d.BundleId);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProductCreatedByNavigations).HasForeignKey(d => d.CreatedBy);

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ProductModifiedByNavigations).HasForeignKey(d => d.ModifiedBy);

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products).HasForeignKey(d => d.ProductCategoryId);

            entity.HasOne(d => d.Subscription).WithMany(p => p.Products).HasForeignKey(d => d.SubscriptionId);

            entity.HasOne(d => d.Warranty).WithMany(p => p.Products).HasForeignKey(d => d.WarrantyId);
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_ProductCategories_Name").IsUnique();

            entity.HasIndex(e => e.Name, "IDX_ProductCategories_Name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_Roles_Name").IsUnique();

            entity.HasIndex(e => e.DepartmentId, "IDX_Roles_DepartmentId");

            entity.HasIndex(e => e.Name, "IDX_Roles_Name");

            entity.HasOne(d => d.Department).WithMany(p => p.Roles).HasForeignKey(d => d.DepartmentId);
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasIndex(e => e.PermissionId, "IDX_RolePermissions_PermissionId");

            entity.HasIndex(e => e.RoleId, "IDX_RolePermissions_RoleId");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasIndex(e => e.UserName, "IX_Sellers_UserName").IsUnique();

            entity.HasIndex(e => e.AddressId, "IDX_Sellers_AddressId");

            entity.HasIndex(e => e.ContactInformationId, "IDX_Sellers_ContactInformationId");

            entity.HasIndex(e => e.SellerTypeId, "IDX_Sellers_SellerTypeId");

            entity.HasIndex(e => e.UserName, "IDX_Sellers_UserName");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Address).WithMany(p => p.Sellers).HasForeignKey(d => d.AddressId);

            entity.HasOne(d => d.ContactInformation).WithMany(p => p.Sellers).HasForeignKey(d => d.ContactInformationId);

            entity.HasOne(d => d.SellerType).WithMany(p => p.Sellers)
                .HasForeignKey(d => d.SellerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SellerProduct>(entity =>
        {
            entity.HasIndex(e => e.ProductId, "IDX_SellerProducts_ProductId");

            entity.HasIndex(e => e.SellerId, "IDX_SellerProducts_SellerId");

            entity.HasOne(d => d.Product).WithMany(p => p.SellerProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Seller).WithMany(p => p.SellerProducts)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SellerType>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_SellerTypes_Name").IsUnique();

            entity.HasIndex(e => e.Name, "IDX_SellerTypes_Name");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_Subscriptions_Name").IsUnique();

            entity.HasIndex(e => e.Name, "IDX_Subscriptions_Name");

            entity.Property(e => e.Price)
                .HasDefaultValueSql("0")
                .HasColumnType("NUMERIC");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.UserName, "IX_Users_UserName").IsUnique();

            entity.HasIndex(e => e.ContactInformationId, "IDX_Users_ContactInformationId");

            entity.HasIndex(e => e.MainRoleId, "IDX_Users_MainRoleId");

            entity.HasIndex(e => e.UserName, "IDX_Users_UserName");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IsActive).HasDefaultValue(1);

            entity.HasOne(d => d.ContactInformation).WithMany(p => p.Users).HasForeignKey(d => d.ContactInformationId);

            entity.HasOne(d => d.MainRole).WithMany(p => p.Users).HasForeignKey(d => d.MainRoleId);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IDX_UserRoles_RoleId");

            entity.HasIndex(e => e.UserId, "IDX_UserRoles_UserId");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasIndex(e => e.Code, "IDX_Warehouses_Code");

            entity.HasIndex(e => e.LocationId, "IDX_Warehouses_LocationId");

            entity.HasOne(d => d.Location).WithMany(p => p.Warehouses).HasForeignKey(d => d.LocationId);
        });

        modelBuilder.Entity<Warranty>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_Warranties_Name").IsUnique();

            entity.HasIndex(e => e.Name, "IDX_Warranties_Name");

            entity.Property(e => e.DurationDays).HasDefaultValue(28);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
