using EshopGoralskiePrzysmaki.DTO.Categories;
using EshopGoralskiePrzysmaki.Exceptions;
using EshopGoralskiePrzysmaki.Models;
using EshopGoralskiePrzysmaki.Repositories.Categories;
using EshopGoralskiePrzysmaki.Services.Validation.Categories;
using Microsoft.AspNetCore.Mvc;

namespace EshopGoralskiePrzysmaki.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController: ApiController
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryValidationService _categoryValidationService;

    public CategoriesController(ICategoryRepository categoryRepository, ICategoryValidationService categoryValidationService)
    {
        _categoryRepository = categoryRepository;
        _categoryValidationService = categoryValidationService;
    }

    [HttpGet(Name = "GetCategories")]
    public ActionResult<CategoryListDto> ListCategories()
    {
        var categories = _categoryRepository.GetCategories();
        
        var categoryListDto = new CategoryListDto();
        categoryListDto.CopyFrom(categories);
        
        return ResponseSuccess(categoryListDto);
    }

    [HttpGet("{id:int}", Name = "GetCategoryDetails")]
    public ActionResult<CategoryResourceDto> GetById(int id)
    {
        try
        {
            var category = _categoryRepository.GetCategoryById(id);

            var categoryResourceDto = new CategoryResourceDto();
            categoryResourceDto.CopyFrom(category);

            return ResponseSuccess(categoryResourceDto);
        }
        catch (ModelNotFoundException e)
        {
            return ResponseNotFound(e);
        }
    }

    [HttpPost(Name = "CreateCategory")]
    public ActionResult<CategoryResourceDto> Post([FromBody] CreateOrUpdateCategoryDto createOrUpdateCategoryDto)
    {
        try
        {
            _categoryValidationService.ValidateCategory(createOrUpdateCategoryDto);
        }
        catch (BadRequestException e)
        {
            return ResponseBadRequest(e);
        }

        var category = new Category()
        {
            Name = createOrUpdateCategoryDto.Name,
        };

        _categoryRepository.AddCategory(category);

        var categoryResourceDto = new CategoryResourceDto();
        categoryResourceDto.CopyFrom(category);

        return ResponseSuccess(categoryResourceDto);
    }

    [HttpDelete("{id:int}", Name = "DeleteCategory")]
    public ActionResult Delete(int id)
    {
        try
        {
            var category = _categoryRepository.GetCategoryById(id);
            _categoryRepository.DeleteCategory(category);

            return ResponseSuccess(new { id = category.Id });
        }
        catch (ModelNotFoundException e)
        {
            return ResponseNotFound(e);
        }
    }

    [HttpPut("{id:int}",  Name = "UpdateCategory")]
    public ActionResult<CategoryResourceDto> Put(int id, [FromBody] CreateOrUpdateCategoryDto updateCategoryDto)
    {
        try
        {
            _categoryValidationService.ValidateCategory(updateCategoryDto);
            var category = _categoryRepository.GetCategoryById(id);
            category.Name = updateCategoryDto.Name;
            _categoryRepository.UpdateCategory(category);

            var categoryResourceDto = new CategoryResourceDto();
            categoryResourceDto.CopyFrom(category);

            return ResponseSuccess(categoryResourceDto);
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
}