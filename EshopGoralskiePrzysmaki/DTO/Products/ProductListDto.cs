using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.DTO.Products;

public class ProductListDto
{
    public List<ProductDto> Products { get; set; } = [];

    public void CopyFrom(IEnumerable<Product> products)
    {
        foreach (var product in products)
        {
            var productDto = new ProductDto();
            productDto.CopyFrom(product);
            Products.Add(productDto);
        }
    }
}