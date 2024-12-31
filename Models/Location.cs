using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class Location
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public int? AddressId { get; set; }

    public string? Notes { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<DepartmentLocation> DepartmentLocations { get; set; } = new List<DepartmentLocation>();

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
