namespace EshopGoralskiePrzysmaki.DTO.Client;

public class ClientDetailsDto: AbstractModelDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }

    public void CopyFrom(Models.Client client)
    {
        FirstName = client.FirstName;
        LastName = client.LastName;
        Address = client.Address;
        Email = client.Email;

        base.CopyFrom(client);
    }
}