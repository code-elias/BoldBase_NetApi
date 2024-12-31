using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class Seller
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Alias { get; set; }

    public string SellerTypeId { get; set; } = null!;

    public int? ContactInformationId { get; set; }

    public int? AddressId { get; set; }

    public string? CreatedAt { get; set; }

    public string? Notes { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ContactInformation? ContactInformation { get; set; }

    public virtual ICollection<SellerProduct> SellerProducts { get; set; } = new List<SellerProduct>();

    public virtual SellerType SellerType { get; set; } = null!;
}
