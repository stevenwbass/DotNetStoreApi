using System;
using System.Collections.Generic;

namespace StoreData.Models;

public partial class Product
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public uint? ProductStatusId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedOn { get; set; }

    public virtual Productstatus? ProductStatus { get; set; }
}
