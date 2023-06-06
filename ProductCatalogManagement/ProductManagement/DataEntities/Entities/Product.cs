using System;
using System.Collections.Generic;

namespace DataEntities.Entities;

public partial class Product
{
    public Guid PId { get; set; }

    public string ProductName { get; set; } = null!;

    public int? Cost { get; set; }

    public string? About { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
