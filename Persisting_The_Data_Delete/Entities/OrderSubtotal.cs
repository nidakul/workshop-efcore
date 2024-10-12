using System;
using System.Collections.Generic;

namespace Persisting_The_Data_Delete.Entities;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
