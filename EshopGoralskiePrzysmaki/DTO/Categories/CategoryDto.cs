using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.DTO.Categories;

public class CategoryDto: AbstractModelDto
{
    public string Name { get; set; }

    public void CopyFrom(Category category)
    {
        Name = category.Name;
        
        base.CopyFrom(category);
    }
}