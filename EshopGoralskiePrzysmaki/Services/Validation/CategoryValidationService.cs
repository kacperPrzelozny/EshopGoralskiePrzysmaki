using EshopGoralskiePrzysmaki.DTO.Categories;
using EshopGoralskiePrzysmaki.Exceptions;
using EshopGoralskiePrzysmaki.Repositories.Categories;

namespace EshopGoralskiePrzysmaki.Services.Validation;

public class CategoryValidationService: ICategoryValidationService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryValidationService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public void ValidateCategory(CreateCategoryDto createCategoryDto)
    {
        ValidateName(createCategoryDto.Name);
    }

    private void ValidateName(string name)
    {
        if (_categoryRepository.CategoryExists(name))
        {
            throw new BadRequestException($"Category with name {name} already exists.");
        }
    }
}