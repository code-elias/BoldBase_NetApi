using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class Warranty
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Notes { get; set; }

    public int DurationDays { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
