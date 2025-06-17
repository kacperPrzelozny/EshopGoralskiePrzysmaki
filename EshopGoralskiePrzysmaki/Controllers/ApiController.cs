using EshopGoralskiePrzysmaki.Exception;
using EshopGoralskiePrzysmaki.Exceptions;
using EshopGoralskiePrzysmaki.Models;
using Microsoft.AspNetCore.Mvc;

namespace EshopGoralskiePrzysmaki.Controllers;

public class ApiController: ControllerBase
{
    protected OkObjectResult ResponseSuccess(object result)
    {
        return Ok(result);
    }

    protected NotFoundObjectResult ResponseNotFound(ModelNotFoundException e)
    {
        return NotFound(new {
            status = 404,
            message = e.Message,
        });
    }

    protected BadRequestObjectResult ResponseBadRequest(BadRequestException e)
    {
        return BadRequest(new
        {
            status = 400,
            message = e.Message,
        });
    }
}