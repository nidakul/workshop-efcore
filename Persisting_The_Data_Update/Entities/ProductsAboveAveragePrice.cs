﻿using System;
using System.Collections.Generic;

namespace Persisting_The_Data_Update.Entities;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}