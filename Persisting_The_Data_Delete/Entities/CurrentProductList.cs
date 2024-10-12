using System;
using System.Collections.Generic;

namespace Persisting_The_Data_Delete.Entities;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
