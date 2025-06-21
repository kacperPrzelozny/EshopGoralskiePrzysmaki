using EshopGoralskiePrzysmaki.DTO.Categories;

namespace EshopGoralskiePrzysmaki.Services.Validation.Categories;

public interface ICategoryValidationService
{
    public void ValidateCategory(CreateOrUpdateCategoryDto createOrUpdateCategoryDto);
}