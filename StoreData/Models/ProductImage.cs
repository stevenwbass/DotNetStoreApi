using System;
using System.Collections.Generic;

namespace StoreData.Models;

public partial class ProductImage
{
    public uint ProductId { get; set; }

    public uint ImageId { get; set; }

    public virtual Image Image { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
