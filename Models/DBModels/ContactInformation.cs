using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class ContactInformation
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? PhoneCountryCode { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Seller> Sellers { get; set; } = new List<Seller>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
