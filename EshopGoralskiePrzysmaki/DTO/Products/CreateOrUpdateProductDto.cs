namespace EshopGoralskiePrzysmaki.DTO.Products;

public class CreateOrUpdateProductDto
{
    public int CategoryId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Sku { get; set; }
    public required decimal Price { get; set; }
}