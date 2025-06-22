namespace EshopGoralskiePrzysmaki.DTO.Carts;

public class CartListDto
{
    public List<CartDto> Carts { get; set; } = [];

    public void CopyFrom(IEnumerable<Models.Cart> carts)
    {
        foreach (var cart in carts)
        {
            var cartDto = new CartDto();
            cartDto.CopyFrom(cart);
            Carts.Add(cartDto);
        }
    }
}