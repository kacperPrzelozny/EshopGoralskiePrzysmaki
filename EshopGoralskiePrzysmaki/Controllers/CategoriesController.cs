using EshopGoralskiePrzysmaki.DTO.Categories;
using EshopGoralskiePrzysmaki.Exceptions;
using EshopGoralskiePrzysmaki.Models;
using EshopGoralskiePrzysmaki.Repositories.Categories;
using EshopGoralskiePrzysmaki.Services.Validation;
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
        
        return ResponseSuccess(new {categories = categoryListDto});
    }

    [HttpGet("{id}", Name = "GetCategoryDetails")]
    public ActionResult<CategoryResourceDto> GetById(int id)
    {
        try
        {
            var category = _categoryRepository.GetCategoryById(id);
            var categoryDto = new CategoryDto();
            categoryDto.CopyFrom(category);

            var categoryResourceDto = new CategoryResourceDto();
            categoryResourceDto.CopyFrom(categoryDto);

            return ResponseSuccess(categoryResourceDto);
        }
        catch (ModelNotFoundException e)
        {
            return ResponseNotFound(e);
        }
    }

    [HttpPost(Name = "CreateCategory")]
    public ActionResult<CategoryResourceDto> Post([FromBody] CreateCategoryDto createCategoryDto)
    {
        try
        {
            _categoryValidationService.ValidateCategory(createCategoryDto);
        }
        catch (BadRequestException e)
        {
            return ResponseBadRequest(e);
        }

        var category = new Category()
        {
            Name = createCategoryDto.Name,
        };

        _categoryRepository.AddCategory(category);

        var categoryDto = new CategoryDto();
        categoryDto.CopyFrom(category);
            
        var categoryResourceDto = new CategoryResourceDto();
        categoryResourceDto.CopyFrom(categoryDto);

        return ResponseSuccess(categoryResourceDto);
    }

    [HttpDelete("{id}", Name = "DeleteCategory")]
    public ActionResult Delete(int id)
    {
        try
        {
            var category = _categoryRepository.GetCategoryById(id);
            _categoryRepository.DeleteCategory(category.Id);

            return ResponseSuccess(new { id = category.Id });
        }
        catch (ModelNotFoundException e)
        {
            return ResponseNotFound(e);
        }
    }

    [HttpPut("{id}",  Name = "UpdateCategory")]
    public ActionResult<CategoryResourceDto> Put(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
    {
        try
        {
            var category = _categoryRepository.GetCategoryById(id);
            category.Name = updateCategoryDto.Name;
            _categoryRepository.UpdateCategory(category);
            
            var categoryDto = new CategoryDto();
            categoryDto.CopyFrom(category);

            var categoryResourceDto = new CategoryResourceDto();
            categoryResourceDto.CopyFrom(categoryDto);

            return ResponseSuccess(categoryResourceDto);
        }
        catch (ModelNotFoundException e)
        {
            return ResponseNotFound(e);
        }
    }
}