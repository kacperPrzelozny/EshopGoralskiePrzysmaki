using EshopGoralskiePrzysmaki.DTO.CartProducts;
using EshopGoralskiePrzysmaki.DTO.Carts;
using EshopGoralskiePrzysmaki.Exceptions;
using EshopGoralskiePrzysmaki.Repositories.Carts;
using EshopGoralskiePrzysmaki.Repositories.Products;
using EshopGoralskiePrzysmaki.Services.Validation.Carts;
using Microsoft.AspNetCore.Mvc;

namespace EshopGoralskiePrzysmaki.Controllers;

[ApiController]
[Route("[controller]")]
public class CartsController : ApiController
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICartValidationService _cartValidationService;

    public CartsController(
        ICartRepository cartRepository,
        IProductRepository productRepository,
        ICartValidationService cartValidationService
    ) {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _cartValidationService = cartValidationService;
    }

    [HttpPost("AddProductToCart")]
    public ActionResult<CartProductResourceDto> AddProductToCart([FromForm] AddProductToCartDto  addProductToCartDto)
    {
        try
        {
            _cartValidationService.ValidateCart(addProductToCartDto);
            var product = _productRepository.GetProductById(addProductToCartDto.ProductId);

            // clientId is const - normally this would come from auth token
            var cart = _cartRepository.GetByClientId(1);
            var cartProductResourceDto = new CartProductResourceDto();

            var cartProduct = _cartRepository.GetProductFromCart(cart.Id, addProductToCartDto.ProductId);
            if (cartProduct == null)
            {
                cartProduct = new Models.CartProduct()
                {
                    CartId = cart.Id,
                    ProductId = addProductToCartDto.ProductId,
                    Quantity = addProductToCartDto.Quantity,
                };

                _cartRepository.AddToCart(cartProduct);
                cartProductResourceDto.CopyFrom(cartProduct, product);
            }
            else
            {
                cartProduct.Quantity += addProductToCartDto.Quantity;
                _cartRepository.UpdateProductInCart(cartProduct);
                cartProductResourceDto.CopyFrom(cartProduct, product);
            }

            return ResponseSuccess(cartProductResourceDto);
        }
        catch (ModelNotFoundException e)
        {
            return ResponseNotFound(e);
        }
        catch (BadRequestException e)
        {
            return ResponseBadRequest(e);
        }
    }

    [HttpPost("RemoveProductFromCart")]
    public ActionResult RemoveProductFromCart([FromForm] RemoveProductFromCartDto removeProductFromCartDto)
    {
        try
        {
            // clientId is const - normally this would come from auth token
            var cart = _cartRepository.GetByClientId(1);
            _cartValidationService.ValidateRemoveProductFromCart(removeProductFromCartDto, cart.Id);

            var cartProduct = _cartRepository.GetProductFromCart(cart.Id, removeProductFromCartDto.ProductId);
            if (cartProduct == null)
            {
                throw new ModelNotFoundException("Product is not added to cart");
            }

            _cartRepository.RemoveFromCart(cartProduct);

            return ResponseSuccess(new { id = cartProduct.Id });
        }
        catch (ModelNotFoundException e)
        {
            return ResponseNotFound(e);
        }
        catch (BadRequestException e)
        {
            return ResponseBadRequest(e);
        }
    }

    [HttpGet("MyCart")]
    public ActionResult<CartResourceDto> GetCart()
    {
        try
        {
            // clientId is const - normally this would come from auth token
            var cart =_cartRepository.GetByClientId(1);
            var cartProducts = _cartRepository.GetProductsFromCart(cart.Id);

            var totalValue = 0.0;
            var cartProductsDtos = new List<CartProductDto>();

            foreach (var cartProduct in cartProducts) {
                var product = _productRepository.GetProductById(cartProduct.ProductId);
                totalValue += (double)(product.Price * cartProduct.Quantity);

                var cartProductDto = new CartProductDto();
                cartProductDto.CopyFrom(cartProduct, product);
                cartProductsDtos.Add(cartProductDto);
            }

            var cartResourceDto = new CartResourceDto();
            cartResourceDto.CopyFrom(cart, totalValue, cartProductsDtos);
            
            return ResponseSuccess(cartResourceDto);
        }
        catch (ModelNotFoundException e)
        {
            return ResponseNotFound(e);
        }
    }

    [HttpGet]
    public ActionResult<CartListDto> GetAllCarts()
    {
        var carts = _cartRepository.GetAll();
        var cartListDto = new CartListDto();
        cartListDto.CopyFrom(carts);

        return ResponseSuccess(cartListDto);
    }
}