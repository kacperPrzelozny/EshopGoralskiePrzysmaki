using EshopGoralskiePrzysmaki.DTO.Categories;
using EshopGoralskiePrzysmaki.Exceptions;
using EshopGoralskiePrzysmaki.Repositories.Categories;

namespace EshopGoralskiePrzysmaki.Services.Validation.Categories;

public class CategoryValidationService: ICategoryValidationService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryValidationService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public void ValidateCategory(CreateOrUpdateCategoryDto createOrUpdateCategoryDto)
    {
        ValidateName(createOrUpdateCategoryDto.Name);
    }

    private void ValidateName(string name)
    {
        if (_categoryRepository.CategoryExists(name))
        {
            throw new BadRequestException($"Category with name {name} already exists.");
        }

        switch (name.Length)
        {
            case < 1:
                throw new BadRequestException("Category name cannot be empty.");
            case > 50:
                throw new BadRequestException($"Category with name {name} length exceeds 50 characters.");
        }
    }
}