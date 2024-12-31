using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class Inventory
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public decimal? QuantityInStock { get; set; }

    public string? MeasureUnit { get; set; }

    public decimal? ReorderLevel { get; set; }

    public int? DefaultWarehouseId { get; set; }

    public string? LastReorder { get; set; }

    public string? CreatedAt { get; set; }

    public int? ModifiedBy { get; set; }

    public string? ModifiedAt { get; set; }

    public virtual ICollection<InventoryWarehouse> InventoryWarehouses { get; set; } = new List<InventoryWarehouse>();

    public virtual Product? Product { get; set; }
}
