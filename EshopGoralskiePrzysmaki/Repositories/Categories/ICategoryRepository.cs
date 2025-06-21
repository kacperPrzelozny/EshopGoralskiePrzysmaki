using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.Repositories.Categories;

public interface ICategoryRepository
{
    IEnumerable<Category> GetCategories();
    Category GetCategoryById(int id);
    bool CategoryExists(string name);
    void AddCategory(Category category);
    void UpdateCategory(Category category);
    void DeleteCategory(Category category);
}