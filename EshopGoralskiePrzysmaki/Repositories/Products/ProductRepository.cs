using EshopGoralskiePrzysmaki.Exceptions;
using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.Repositories.Products;

public class ProductRepository: IProductRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public ProductRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }
    
    public IEnumerable<Product> GetProducts(int categoryId = 0)
    {
        if (categoryId == 0)
            return _dbContext.Products.ToList();
        
        return _dbContext.Products.Where(p => p.CategoryId == categoryId);
    }

    public Product GetProductById(int id)
    {
        var product = _dbContext.Products.Find(id);
        if (product == null)
        {
            throw new ModelNotFoundException("No product found with id: " + id);
        }
        return product;
    }

    public bool ProductExists(string sku)
    {
        return _dbContext.Products.FirstOrDefault(c => c.Sku == sku) != null;
    }

    public void AddProduct(Product product)
    {
        product.Created = DateTime.Now;
        product.Edited = DateTime.Now;
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        product.Edited = DateTime.Now;
        _dbContext.Products.Update(product);
        _dbContext.SaveChanges();
    }

    public void DeleteProduct(Product product)
    {
        _dbContext.Products.Remove(product);
    }
}