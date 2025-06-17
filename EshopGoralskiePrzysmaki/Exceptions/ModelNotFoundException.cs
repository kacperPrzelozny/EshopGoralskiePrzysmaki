using EshopGoralskiePrzysmaki.Exception;

namespace EshopGoralskiePrzysmaki.Exceptions;

public class ModelNotFoundException : BaseException
{
    public ModelNotFoundException(string message) : base(message)
    {
    }
}