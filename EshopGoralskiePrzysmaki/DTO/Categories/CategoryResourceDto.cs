using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.DTO.Categories;

public class CategoryResourceDto
{
    public CategoryDto Category { get; set; }

    public void CopyFrom(Category category)
    {
        var categoryDto = new CategoryDto();
        categoryDto.CopyFrom(category);

        Category = categoryDto;
    }
}