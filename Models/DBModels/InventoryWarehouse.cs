using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class InventoryWarehouse
{
    public int Id { get; set; }

    public int? InventoryId { get; set; }

    public int? WarehouseId { get; set; }

    public virtual Inventory? Inventory { get; set; }

    public virtual Warehouse? Warehouse { get; set; }
}
