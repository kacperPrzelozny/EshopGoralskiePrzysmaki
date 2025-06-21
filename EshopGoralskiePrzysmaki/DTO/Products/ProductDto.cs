using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.DTO.Products;

public class ProductDto: AbstractModelDto
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Sku { get; set; }
    public decimal Price { get; set; }

    public void CopyFrom(Product product)
    {
        CategoryId = product.CategoryId;
        Name = product.Name;
        Description = product.Description;
        Sku = product.Sku;
        Price = product.Price;
        
        base.CopyFrom(product);
    }
}