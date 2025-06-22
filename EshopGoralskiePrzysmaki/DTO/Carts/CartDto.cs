using EshopGoralskiePrzysmaki.DTO.CartProducts;
using EshopGoralskiePrzysmaki.DTO.Products;
using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.DTO.Carts;

public class CartDto: AbstractModelDto
{
    public int ClientId { get; set; }
    public double TotalValue { get; set; }
    public List<CartProductDto> CartProducts { get; set; } = [];

    public void CopyFrom(Cart cart, double totalValue, IEnumerable<CartProductDto> cartProductsDtos)
    {
        ClientId = cart.ClientId;
        TotalValue = totalValue;
        CartProducts.AddRange(cartProductsDtos);

        base.CopyFrom(cart);
    }
}