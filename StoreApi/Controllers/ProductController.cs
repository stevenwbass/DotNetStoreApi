using Microsoft.AspNetCore.Mvc;
using StoreData.Managers;
using StoreData.CustomModels.Products;

namespace StoreApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductsManager _productsManager;

    public ProductsController(IProductsManager productsManager) {
        _productsManager = productsManager;
    }

    [HttpGet]
    public async Task<Product[]> GetProducts() {
        var productQuery = new ProductQuery();
        return (await _productsManager.GetProductsAsync(productQuery)).ToArray();
    }

    [HttpPost]
    public static Product CreateProduct(Product product) {
        return new Product();
    }
}