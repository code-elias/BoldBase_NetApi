using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Alias { get; set; }

    public string CustomerTypeId { get; set; } = null!;

    public int? ContactInformationId { get; set; }

    public int? AddressId { get; set; }

    public string? CreatedAt { get; set; }

    public string? Notes { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ContactInformation? ContactInformation { get; set; }

    public virtual ICollection<CustomerProduct> CustomerProducts { get; set; } = new List<CustomerProduct>();

    public virtual CustomerType CustomerType { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
