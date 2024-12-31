using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class Address
{
    public int Id { get; set; }

    public string Address1 { get; set; } = null!;

    public string? ZipCode { get; set; }

    public string CountryCode { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();
}
