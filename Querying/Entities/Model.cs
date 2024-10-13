using System;
using System.Collections.Generic;

namespace Querying.Entities;

public partial class Model
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public string Name { get; set; } = null!;

    public decimal DailyPrice { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual Brand Brand { get; set; } = null!;
}
