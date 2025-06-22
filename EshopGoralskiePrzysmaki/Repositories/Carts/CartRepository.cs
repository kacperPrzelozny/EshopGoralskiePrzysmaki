using EshopGoralskiePrzysmaki.Exceptions;
using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.Repositories.Carts;

public class CartRepository : ICartRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CartRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public Cart GetById(int id)
    {
        var cart = _dbContext.Carts.FirstOrDefault(x => x.Id == id);
        if (cart == null)
        {
            throw new ModelNotFoundException("Cart not found");
        }

        return cart;
    }

    public Cart GetByClientId(int clientId)
    {
        var cart = _dbContext.Carts.FirstOrDefault(x => x.ClientId == clientId);
        if (cart == null)
        {
            throw new ModelNotFoundException("Cart not found");
        }

        return cart;
    }

    public IEnumerable<Cart> GetAll()
    {
        return _dbContext.Carts.ToList();
    }

    public IEnumerable<CartProduct> GetProductsFromCart(int cartId)
    {
        return _dbContext.CartProducts.Where(cartProduct => cartProduct.CartId == cartId).ToList();
    }

    public CartProduct? GetProductFromCart(int cartId, int productId)
    {
        var cartProduct =
            _dbContext.CartProducts
                .Where(cartProduct => cartProduct.CartId == cartId)
                .FirstOrDefault(cartProduct => cartProduct.ProductId == productId);

        return cartProduct;
    }

    public void AddToCart(CartProduct cartProduct)
    {
        cartProduct.Created = DateTime.Now;
        cartProduct.Edited = DateTime.Now;
        _dbContext.CartProducts.Add(cartProduct);
        _dbContext.SaveChanges();
    }

    public void UpdateProductInCart(CartProduct cartProduct)
    {
        cartProduct.Edited = DateTime.Now;
        _dbContext.CartProducts.Update(cartProduct);
        _dbContext.SaveChanges();
    }

    public void RemoveFromCart(CartProduct cartProduct)
    {
        _dbContext.CartProducts.Remove(cartProduct);
        _dbContext.SaveChanges();
    }
}