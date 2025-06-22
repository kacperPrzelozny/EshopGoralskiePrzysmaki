using EshopGoralskiePrzysmaki.DTO.CartProducts;
using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.DTO.Carts;

public class CartResourceDto
{
    public CartDto Cart { get; set; }

    public void CopyFrom(Cart cart, double totalValue, IEnumerable<CartProductDto> cartProductsDtos)
    {
        var cartDto = new CartDto();
        cartDto.CopyFrom(cart, totalValue, cartProductsDtos);
        
        Cart = cartDto;
    }
}