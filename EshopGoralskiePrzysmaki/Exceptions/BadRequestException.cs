using EshopGoralskiePrzysmaki.Exception;

namespace EshopGoralskiePrzysmaki.Exceptions;

public class BadRequestException: BaseException
{
    public BadRequestException(string message) : base(message)
    {
    }
}