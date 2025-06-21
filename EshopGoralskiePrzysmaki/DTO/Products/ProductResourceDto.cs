using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.DTO.Products;

public class ProductResourceDto
{
    public ProductDto Product { get; set; }

    public void CopyFrom(Product product)
    {
        var productDto = new ProductDto();
        productDto.CopyFrom(product);

        Product = productDto;
    }
}