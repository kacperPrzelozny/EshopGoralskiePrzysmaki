namespace EshopGoralskiePrzysmaki.Models;

public class CartProduct: Model
{
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}