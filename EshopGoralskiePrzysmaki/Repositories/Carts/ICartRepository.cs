using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.Repositories.Carts;

public interface ICartRepository
{
    public Cart GetById(int id);
    public Cart GetByClientId(int clientId);
    public IEnumerable<Cart> GetAll();
    public IEnumerable<CartProduct> GetProductsFromCart(int cartId);
    public CartProduct? GetProductFromCart(int cartId, int productId);
    public void AddToCart(CartProduct cartProduct);
    public void UpdateProductInCart(CartProduct cartProduct);
    public void RemoveFromCart(CartProduct cartProduct);
}