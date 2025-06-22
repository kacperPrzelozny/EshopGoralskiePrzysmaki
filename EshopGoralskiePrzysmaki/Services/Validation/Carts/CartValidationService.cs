using EshopGoralskiePrzysmaki.DTO.Carts;
using EshopGoralskiePrzysmaki.Exceptions;
using EshopGoralskiePrzysmaki.Repositories.Carts;
using EshopGoralskiePrzysmaki.Repositories.Products;

namespace EshopGoralskiePrzysmaki.Services.Validation.Carts;

public class CartValidationService: ICartValidationService
{
    private readonly IProductRepository _productRepository;
    private readonly ICartRepository _cartRepository;

    public CartValidationService(IProductRepository productRepository, ICartRepository cartRepository)
    {
        _productRepository = productRepository;
        _cartRepository = cartRepository;
    }

    public void ValidateCart(AddProductToCartDto addProductToCartDto)
    {
        ValidateProductId(addProductToCartDto.ProductId);
        ValidateQuantity(addProductToCartDto.Quantity);
    }

    public void ValidateRemoveProductFromCart(RemoveProductFromCartDto removeProductFromCartDto, int cartId)
    {
        ValidateProductId(removeProductFromCartDto.ProductId);
        ValidateProductInCart(cartId, removeProductFromCartDto.ProductId);
    }

    private void ValidateProductId(int productId)
    {
        _productRepository.GetProductById(productId);
    }

    private void ValidateProductInCart(int cartId, int productId)
    {
        var cartProduct = _cartRepository.GetProductFromCart(cartId, productId);
        if (cartProduct == null) {
            throw new ModelNotFoundException("Product has to be in cart to remove it");
        }
    }

    private static void ValidateQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new BadRequestException("Quantity has to be positive integer");
        }
    }
}