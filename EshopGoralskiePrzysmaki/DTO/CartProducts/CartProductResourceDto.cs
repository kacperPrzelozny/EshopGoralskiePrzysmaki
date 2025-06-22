using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.DTO.CartProducts;

public class CartProductResourceDto
{
    public CartProductDto CartProduct { get; set; }

    public void CopyFrom(CartProduct cartProduct, Product product)
    {
        var cartProductDto = new CartProductDto();
        cartProductDto.CopyFrom(cartProduct, product);
        CartProduct = cartProductDto;
    }
}