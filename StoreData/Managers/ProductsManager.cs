using Product = StoreData.CustomModels.Products.Product;
using StoreData.Models;
using StoreData.CustomModels.Products;
using Microsoft.EntityFrameworkCore;

namespace StoreData.Managers;

public class ProductsManager : IProductsManager
{
    private StoreDbContext _storeDbContext;

    public ProductsManager(StoreDbContext storeDbContext) {
        _storeDbContext = storeDbContext;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(ProductQuery query) {
        var dbProducts = await _storeDbContext.Products.Where(x => x.Name.Contains(query.ProductName)).ToListAsync();
        var results = dbProducts.Select(x => new Product{
            Id = x.Id,
            Name = x.Name,
            Price = x.Price,
            ProductStatusId = x.ProductStatusId,
            CreatedBy = x.CreatedBy,
            // CreatedOn = x.CreatedOn,
            UpdatedBy = x.UpdatedBy,
            UpdatedOn = x.UpdatedOn
        });
        return results;
    }
}