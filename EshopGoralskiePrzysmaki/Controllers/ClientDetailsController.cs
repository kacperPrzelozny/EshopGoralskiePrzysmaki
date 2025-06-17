using EshopGoralskiePrzysmaki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EshopGoralskiePrzysmaki.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientDetailsController: ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public ClientDetailsController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
   
    [HttpGet(Name = "GetClientDetails")]
    public ActionResult<Client> GetById()
    {
        var Client = _dbContext.Clients.Find(1);
        if (Client == null)
        {
            return NotFound();
        }
        return Client;
    }
}