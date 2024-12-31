using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class DepartmentLocation
{
    public int Id { get; set; }

    public int? DepartmentId { get; set; }

    public int? LocationId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Location? Location { get; set; }
}
