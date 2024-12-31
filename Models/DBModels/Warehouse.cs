using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class Warehouse
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public int? LocationId { get; set; }

    public string? CreatedAt { get; set; }

    public virtual ICollection<InventoryWarehouse> InventoryWarehouses { get; set; } = new List<InventoryWarehouse>();

    public virtual Location? Location { get; set; }
}
