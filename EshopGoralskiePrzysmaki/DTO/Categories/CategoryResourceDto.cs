namespace EshopGoralskiePrzysmaki.DTO.Categories;

public class CategoryResourceDto
{
    public CategoryDto Category { get; set; }

    public void CopyFrom(CategoryDto categoryDto)
    {
        Category = categoryDto;
    }
}