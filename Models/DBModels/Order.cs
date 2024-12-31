using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class Order
{
    public int Id { get; set; }

    public string OrderNumber { get; set; } = null!;

    public int? CustomerId { get; set; }

    public string? CreatedAt { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}
