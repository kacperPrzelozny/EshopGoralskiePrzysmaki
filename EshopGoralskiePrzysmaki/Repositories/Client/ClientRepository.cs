using EshopGoralskiePrzysmaki.Exceptions;

namespace EshopGoralskiePrzysmaki.Repositories.Client;

public class ClientRepository: IClientRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ClientRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Models.Client GetClient()
    {
        var client = _dbContext.Clients.First();
        if (client == null)
        {
            throw new ModelNotFoundException("Client not found");
        }

        return client;
    }
}