using EshopGoralskiePrzysmaki.DTO.Products;
using EshopGoralskiePrzysmaki.Exceptions;
using EshopGoralskiePrzysmaki.Repositories.Categories;
using EshopGoralskiePrzysmaki.Repositories.Products;

namespace EshopGoralskiePrzysmaki.Services.Validation.Products;

public class ProductValidationService: IProductValidationService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    
    public ProductValidationService(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public void ValidateProduct(CreateOrUpdateProductDto createOrUpdateProductDto)
    {
        if (createOrUpdateProductDto.CategoryId != 0)
        {
            ValidateCategoryId(createOrUpdateProductDto.CategoryId);
        }

        ValidateName(createOrUpdateProductDto.Name);
        ValidateDescription(createOrUpdateProductDto.Description);
        ValidateSku(createOrUpdateProductDto.Sku);
        ValidatePrice(createOrUpdateProductDto.Price);
    }

    private void ValidateCategoryId(int categoryId)
    {
        _categoryRepository.GetCategoryById(categoryId);
    }
    
    private static void ValidateName(string name)
    {
        switch (name.Length)
        {
            case < 1:
                throw new BadRequestException("Product name cannot be empty.");
            case > 255:
                throw new BadRequestException("Product name length exceeds 255 characters.");
        }
    }

    private void ValidateSku(string sku)
    {
        if (_productRepository.ProductExists(sku))
        {
            throw new BadRequestException($"Product with sku {sku} already exists.");
        }

        switch (sku.Length)
        {
            case < 1:
                throw new BadRequestException("Product sku cannot be empty.");
            case > 20:
                throw new BadRequestException($"Product sku length exceeds 20 characters.");
        }
    }

    private static void ValidateDescription(string description)
    {
        switch (description.Length)
        {
            case < 1:
                throw new BadRequestException("Product description cannot be empty.");
            case > 255:
                throw new BadRequestException("Product description length exceeds 255 characters.");
        }
    }

    private static void ValidatePrice(decimal price)
    {
        if (price < 0)
        {
            throw new BadRequestException("Price cannot be negative.");
        }
    }
}