﻿using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public string? Notes { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
