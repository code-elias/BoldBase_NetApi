using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class CustomerProduct
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
