namespace StoreData.CustomModels.Products;

public class Product {
    public uint Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<uint?> ImageIds { get; set; } = new List<uint?>();
    public decimal Price { get; set; }
    public List<uint> CategoryIds { get; set; } = new List<uint>();
    public List<uint> TagIds { get; set; } = new List<uint>();
    public uint? ProductStatusId { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime UpdatedOn { get; set; } = DateTime.Now;
    public string UpdatedBy { get; set; } = string.Empty;
}