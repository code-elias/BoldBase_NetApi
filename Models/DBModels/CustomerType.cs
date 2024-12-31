using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class CustomerType
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
