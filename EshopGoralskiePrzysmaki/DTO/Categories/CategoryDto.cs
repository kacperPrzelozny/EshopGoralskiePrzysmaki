using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.DTO.Categories;

public class CategoryDto: AbstractModelDto
{
    public string Name { get; set; }

    public void CopyFrom(Category category)
    {
        Id = category.Id;
        Name = category.Name;
        Created = category.Created;
        Edited = category.Edited;
    }
}