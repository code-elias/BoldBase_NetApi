using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class Bundle
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Notes { get; set; }

    public decimal Price { get; set; }

    public string DefaultCurrency { get; set; } = null!;

    public string? BarCode { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
