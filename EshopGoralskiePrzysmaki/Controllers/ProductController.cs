using EshopGoralskiePrzysmaki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EshopGoralskiePrzysmaki.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public ProductController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{id}", Name = "GetProductDetails")]
    public ActionResult<Product> GetById(int id)
    {
        var Product = _dbContext.Products.Find(id);
        if (Product == null)
        {
            return NotFound();
        }
        return Product;
    }

    [HttpPost]
    public ActionResult<Product> Post([FromBody] Product Product)
    {

        _dbContext.Products.Add(Product);
        _dbContext.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = Product.Id }, Product);
    }
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var Product = _dbContext.Products.Find(id);
        if (Product == null)
        {
            return NotFound();
        }
        _dbContext.Products.Remove(Product);
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Product> Put(int id, [FromBody] Product Product)
    {
        if (id != Product.Id)
        {
            return BadRequest();
        }
        _dbContext.Entry(Product).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return NoContent();
    }
}