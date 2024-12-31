using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Notes { get; set; }

    public string? CreatedAt { get; set; }

    public virtual ICollection<DepartmentLocation> DepartmentLocations { get; set; } = new List<DepartmentLocation>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
