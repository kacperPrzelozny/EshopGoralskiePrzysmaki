using EshopGoralskiePrzysmaki.DTO.Carts;
using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.Services.Validation.Carts;

public interface ICartValidationService
{
    public void ValidateCart(AddProductToCartDto addProductToCartDto);
    public void ValidateRemoveProductFromCart(RemoveProductFromCartDto removeProductFromCartDto, int cartId);
}