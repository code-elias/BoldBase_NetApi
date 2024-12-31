using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class SellerType
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}
