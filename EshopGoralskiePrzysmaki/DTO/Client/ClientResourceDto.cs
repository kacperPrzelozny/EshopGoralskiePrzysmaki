namespace EshopGoralskiePrzysmaki.DTO.Client;

public class ClientResourceDto
{
    public ClientDetailsDto Client { get; set; }

    public void CopyFrom(Models.Client client)
    {
        var clientDto = new ClientDetailsDto();
        clientDto.CopyFrom(client);
        
        Client = clientDto;
    }
}