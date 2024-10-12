using System;
using System.Collections.Generic;

namespace Persisting_The_Data_Update.Entities;

public partial class CategorySalesFor1997
{
    public string CategoryName { get; set; } = null!;

    public decimal? CategorySales { get; set; }
}
