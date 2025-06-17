using EshopGoralskiePrzysmaki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EshopGoralskiePrzysmaki.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController: ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public CategoriesController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
   

    [HttpGet("{id}", Name = "GetCategoryDetails")]
    public ActionResult<Category> GetById(int id)
    {
        var category = _dbContext.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        return category;
    }

    [HttpPost]
    public ActionResult<Category> Post([FromBody] Category category)
    {
        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var category = _dbContext.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        _dbContext.Categories.Remove(category);
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Category> Put(int id, [FromBody] Category category)
    {
        if (id != category.Id)
        {
            return BadRequest();
        }
        _dbContext.Entry(category).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return NoContent();
    }
}