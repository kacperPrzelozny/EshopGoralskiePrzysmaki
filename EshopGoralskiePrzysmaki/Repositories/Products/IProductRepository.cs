using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.Repositories.Products;

public interface IProductRepository
{
    IEnumerable<Product> GetProducts(int categoryId = 0);
    Product GetProductById(int id);
    bool ProductExists(string sku);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
}