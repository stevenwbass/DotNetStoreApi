using System;
using System.Collections.Generic;

namespace StoreData.Models;

public partial class Category
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;
}
