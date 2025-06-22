namespace EshopGoralskiePrzysmaki.DTO.Carts;

public class AddProductToCartDto
{
    public required int ProductId { get; set; }
    public required int Quantity { get; set; }
}