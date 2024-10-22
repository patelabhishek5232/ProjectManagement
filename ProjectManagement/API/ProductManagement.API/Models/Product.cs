using System;
using System.Collections.Generic;

namespace ProductManagement.API.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public double? Discount { get; set; }

    public DateTime CreateDate { get; set; }

    public bool IsActive { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
