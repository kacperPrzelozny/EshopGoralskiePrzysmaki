namespace EshopGoralskiePrzysmaki.Models;

public class Product: Model
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
}
