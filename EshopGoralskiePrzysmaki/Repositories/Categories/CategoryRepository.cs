using EshopGoralskiePrzysmaki.Exceptions;
using EshopGoralskiePrzysmaki.Models;

namespace EshopGoralskiePrzysmaki.Repositories.Categories;

public class CategoryRepository: ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public CategoryRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }
    
    public IEnumerable<Category> GetCategories()
    {
        return _dbContext.Categories.ToList();
    }

    public Category GetCategoryById(int id)
    {
        var category = _dbContext.Categories.Find(id);
        if (category == null)
        {
            throw new ModelNotFoundException("No category found with id: " + id);
        }
        return category;
    }

    public bool CategoryExists(string name)
    {
        return _dbContext.Categories.FirstOrDefault(c => c.Name == name) != null;
    }

    public void AddCategory(Category category)
    {
        category.Created = DateTime.Now;
        category.Edited = DateTime.Now;
        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
    }

    public void UpdateCategory(Category category)
    {
        category.Edited = DateTime.Now;
        _dbContext.Categories.Update(category);
        _dbContext.SaveChanges();
    }

    public void DeleteCategory(int id)
    {
        
    }
}