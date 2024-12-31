using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FirstNames { get; set; } = null!;

    public string? Alias { get; set; }

    public string LastName { get; set; } = null!;

    public int IsAdmin { get; set; } = 0;

    public int? MainRoleId { get; set; }

    public int IsActive { get; set; } = 1;

    public int? ContactInformationId { get; set; }

    public string? CreatedAt { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ContactInformation? ContactInformation { get; set; }

    public virtual Role? MainRole { get; set; }

    public virtual ICollection<Product> ProductCreatedByNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductModifiedByNavigations { get; set; } = new List<Product>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
