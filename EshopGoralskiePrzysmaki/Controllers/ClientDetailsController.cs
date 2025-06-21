using EshopGoralskiePrzysmaki.DTO.Client;
using EshopGoralskiePrzysmaki.Exceptions;
using EshopGoralskiePrzysmaki.Models;
using EshopGoralskiePrzysmaki.Repositories.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EshopGoralskiePrzysmaki.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientDetailsController: ApiController
{
    private readonly IClientRepository _clientRepository;

    public ClientDetailsController(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
   
    [HttpGet(Name = "GetClientDetails")]
    public ActionResult<ClientResourceDto> GetClientDetails()
    {
        try
        {
            var client = _clientRepository.GetClient();
            var clientResourceDto = new ClientResourceDto();
            clientResourceDto.CopyFrom(client);
            return ResponseSuccess(clientResourceDto);
        }
        catch (ModelNotFoundException e)
        {
            return ResponseNotFound(e);
        }
    }
}