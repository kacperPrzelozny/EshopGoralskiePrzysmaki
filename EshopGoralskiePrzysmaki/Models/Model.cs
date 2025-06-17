namespace EshopGoralskiePrzysmaki.Models;

public abstract class Model
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }
}