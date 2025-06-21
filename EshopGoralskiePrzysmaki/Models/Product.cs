namespace EshopGoralskiePrzysmaki.Models;

public class Product: Model
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Sku { get; set; }
    public decimal Price { get; set; }
}
