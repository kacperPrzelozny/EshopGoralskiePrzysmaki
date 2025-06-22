using EshopGoralskiePrzysmaki.DTO.Products;
using EshopGoralskiePrzysmaki.Exceptions;
using EshopGoralskiePrzysmaki.Models;
using EshopGoralskiePrzysmaki.Repositories.Products;
using EshopGoralskiePrzysmaki.Services.Validation.Products;
using Microsoft.AspNetCore.Mvc;

namespace EshopGoralskiePrzysmaki.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ApiController
{
    private readonly IProductRepository _productRepository;
    private readonly IProductValidationService _productValidationService;

    public ProductsController(IProductRepository productRepository, IProductValidationService productValidationService)
    {
        _productRepository = productRepository;
        _productValidationService = productValidationService;
    }

    [HttpGet(Name = "GetProducts")]
    public ActionResult<ProductListDto> ListProducts([FromQuery] GetProductListDto getProductListDto)
    {
        var categories = _productRepository.GetProducts(getProductListDto.CategoryId);
        
        var categoryListDto = new ProductListDto();
        categoryListDto.CopyFrom(categories);
        
        return ResponseSuccess(categoryListDto);
    }

    [HttpGet("{id:int}", Name = "GetProductDetails")]
    public ActionResult<Product> GetById(int id)
    {
        try
        {
            var product = _productRepository.GetProductById(id);

            var productResourceDto = new ProductResourceDto();
            productResourceDto.CopyFrom(product);

            return ResponseSuccess(productResourceDto);
        }
        catch (ModelNotFoundException e)
        {
            return ResponseNotFound(e);
        }
    }

    [HttpPost]
    public ActionResult<ProductResourceDto> Post([FromBody] CreateOrUpdateProductDto createProductDto)
    {
        try
        {
            _productValidationService.ValidateProduct(createProductDto);
        }
        catch (BadRequestException e)
        {
            return ResponseBadRequest(e);
        }
        catch (ModelNotFoundException e)
        {
            return ResponseNotFound(e);
        }

        var product = new Product()
        {
            CategoryId = createProductDto.CategoryId,
            Name = createProductDto.Name,
            Description = createProductDto.Description,
            Sku = createProductDto.Sku,
            Price = createProductDto.Price,
        };

        _productRepository.AddProduct(product);
        
        var productResourceDto = new ProductResourceDto();
        productResourceDto.CopyFrom(product);
        
        return ResponseSuccess(productResourceDto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<ProductResourceDto> Put(int id, [FromBody] CreateOrUpdateProductDto updateProductDto)
    {
        try
        {
            _productValidationService.ValidateProduct(updateProductDto);
            var product = _productRepository.GetProductById(id);

            product.CategoryId = updateProductDto.CategoryId;
            product.Name = updateProductDto.Name;
            product.Description = updateProductDto.Description;
            product.Sku = updateProductDto.Sku;
            product.Price = updateProductDto.Price;
            
            _productRepository.UpdateProduct(product);

            var productResourceDto = new ProductResourceDto();
            productResourceDto.CopyFrom(product);

            return ResponseSuccess(productResourceDto);
        }
        catch (BadRequestException e)
        {
            return ResponseBadRequest(e);
        }
        catch (ModelNotFoundException e)
        {
            return ResponseNotFound(e);
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        try
        {
            var product = _productRepository.GetProductById(id);
            _productRepository.DeleteProduct(product);

            return ResponseSuccess(new { id = product.Id });
        }
        catch (ModelNotFoundException e)
        {
            return ResponseNotFound(e);
        }
    }
}