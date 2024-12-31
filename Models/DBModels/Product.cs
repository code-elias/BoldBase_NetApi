using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? FreeText { get; set; }

    public string? Notes { get; set; }

    public int IsActive { get; set; }

    public decimal Price { get; set; }

    public string DefaultCurrency { get; set; } = null!;

    public string? BarCode { get; set; }

    public int IsBundled { get; set; }

    public int? BundleId { get; set; }

    public int BundleAmount { get; set; }

    public int? ProductCategoryId { get; set; }

    public string? Vat { get; set; }

    public int IsSoldProduct { get; set; }

    public int IsPurchasedProduct { get; set; }

    public int IsMadeProduct { get; set; }

    public int IsInventoryProduct { get; set; }

    public int IsService { get; set; }

    public int HasWarranty { get; set; }

    public int? WarrantyId { get; set; }

    public int IsSubscription { get; set; }

    public int? SubscriptionId { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public string? ModifiedAt { get; set; }

    public virtual Bundle? Bundle { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<CustomerProduct> CustomerProducts { get; set; } = new List<CustomerProduct>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual ProductCategory? ProductCategory { get; set; }

    public virtual ICollection<SellerProduct> SellerProducts { get; set; } = new List<SellerProduct>();

    public virtual Subscription? Subscription { get; set; }

    public virtual Warranty? Warranty { get; set; }
}
