using EshopGoralskiePrzysmaki.DTO.Categories;

namespace EshopGoralskiePrzysmaki.Services.Validation;

public interface ICategoryValidationService
{
    public void ValidateCategory(CreateCategoryDto createCategoryDto);
}