using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class OrderLine
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public string Currency { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
