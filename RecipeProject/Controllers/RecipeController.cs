using Application;
using Application.Services.Converters;
using Application.Services.RecipeServices;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeService _recipeService;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeController(IRecipeRepository recipeRepository, IRecipeService recipeService, IUnitOfWork unitOfWork)
        {
            _recipeRepository = recipeRepository;
            _recipeService = recipeService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id:int}")]
        public FullRecipe GetRecipeById(int id)
        {
            FullRecipe recipe = _recipeRepository.GetById(id);
            return recipe;
        }

        [HttpPost]
        public void AddRecipe([FromBody] FullRecipeDto recipeDto)
        {
            _recipeService.AddRecipe(recipeDto);
            _unitOfWork.Commit();
        }

        [HttpGet]
        public FullRecipeDto[] GetAllFullRecipe(FullRecipe recipe)
        {
            FullRecipeDto recipeDto = FullRecipeDtoConverter.ConvertToRecipeDto(recipe);
            return _recipeRepository.GetAllFullRecipe();

        }
    }
}
