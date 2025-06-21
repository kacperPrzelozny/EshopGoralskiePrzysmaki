using EshopGoralskiePrzysmaki.DTO.Products;

namespace EshopGoralskiePrzysmaki.Services.Validation.Products;

public interface IProductValidationService
{
    public void ValidateProduct(CreateOrUpdateProductDto createOrUpdateProductDto);
}