using EshopGoralskiePrzysmaki.Models;
using Microsoft.EntityFrameworkCore;

namespace EshopGoralskiePrzysmaki;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
      
    }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}