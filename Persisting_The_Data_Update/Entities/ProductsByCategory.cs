using System;
using System.Collections.Generic;

namespace Persisting_The_Data_Update.Entities;

public partial class ProductsByCategory
{
    public string CategoryName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string? QuantityPerUnit { get; set; }

    public short? UnitsInStock { get; set; }

    public bool Discontinued { get; set; }
}
