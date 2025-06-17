using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EshopGoralskiePrzysmaki.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientDetailsController: ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public ClientDetailsController(ILogger<WeatherForecastController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    
    [HttpGet(Name = "GetClientDetails")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _dbContext.WeatherForecasts.ToList();
    }
    
    [HttpPost]
    public ActionResult<WeatherForecast> Post([FromBody] WeatherForecast weatherForecast)
    {
        if (string.IsNullOrWhiteSpace(weatherForecast.Summary))
        {
            return BadRequest("Weather summary is required.");
        }

        _dbContext.WeatherForecasts.Add(weatherForecast);
        _dbContext.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = weatherForecast.Id }, weatherForecast);
    }
    
    [HttpGet("{id}")]
    public ActionResult<WeatherForecast> GetById(int id)
    {
        var weatherForecast = _dbContext.WeatherForecasts.Find(id);
        if (weatherForecast == null)
        {
            return NotFound();
        }
        return weatherForecast;
    }
}