using System;
using System.Collections.Generic;

namespace RepositoryNetAPI.Models;

public partial class SellerProduct
{
    public int Id { get; set; }

    public int SellerId { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Seller Seller { get; set; } = null!;
}
