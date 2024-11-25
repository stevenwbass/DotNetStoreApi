using StoreData.CustomModels.Products;

namespace StoreData.Managers;

public interface IProductsManager {
    Task<IEnumerable<Product>> GetProductsAsync(ProductQuery query);
}