using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.DTO.CartProducts;

public class CartProductDto: AbstractModelDto
{
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string ProductName { get; set; }
    public string ProductSku { get; set; }
    public double TotalProductPrice { get; set; }

    public void CopyFrom(CartProduct cartProduct, Product product)
    {
        CartId = cartProduct.CartId;
        ProductId = cartProduct.ProductId;
        Quantity = cartProduct.Quantity;
        ProductName = product.Name;
        ProductSku = product.Sku;
        TotalProductPrice = (double) product.Price * Quantity;

        base.CopyFrom(cartProduct);
    }
}