using System;
using System.Collections.Generic;

namespace StoreData.Models;

public partial class Image
{
    public uint Id { get; set; }

    public string? Url { get; set; }

    public string? Base64Bytes { get; set; }
}
