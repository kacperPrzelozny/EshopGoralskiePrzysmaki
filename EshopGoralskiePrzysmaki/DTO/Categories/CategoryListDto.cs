using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.DTO.Categories;

public class CategoryListDto
{
    public List<CategoryDto> Categories { get; set; } = [];

    public void CopyFrom(IEnumerable<Category> categories)
    {
        foreach (var category in categories)
        {
            var categoryDto = new CategoryDto();
            categoryDto.CopyFrom(category);
            Categories.Add(categoryDto);
        }
    }
}