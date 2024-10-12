﻿using System;
using System.Collections.Generic;

namespace Persisting_The_Data_Update.Entities;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}