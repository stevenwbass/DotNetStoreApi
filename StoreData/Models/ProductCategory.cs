﻿using System;
using System.Collections.Generic;

namespace StoreData.Models;

public partial class ProductCategory
{
    public uint ProductId { get; set; }

    public uint CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
