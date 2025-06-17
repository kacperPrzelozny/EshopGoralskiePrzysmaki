namespace EshopGoralskiePrzysmaki.DTO;

public abstract class AbstractModelDto
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }
}