using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class AuditLog
{
    public int Id { get; set; }

    public string TableName { get; set; } = null!;

    public int RecordId { get; set; }

    public string Action { get; set; } = null!;

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public int? ChangedBy { get; set; }

    public string? ChangedAt { get; set; }

    public virtual User? ChangedByNavigation { get; set; }
}
