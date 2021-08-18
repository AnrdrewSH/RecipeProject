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

        public RecipeController(IRecipeRepository recipeRepository, IRecipeService recipeService)
        {
            _recipeRepository = recipeRepository;
            _recipeService = recipeService;
        }

        [HttpGet("{id:int}")]
        public Recipe GetRecipeById(int id)
        {
            Recipe recipe = _recipeRepository.GetById(id);
            return recipe;
        }

        [HttpPost]
        public void AddRecipe([FromBody] RecipeDto recipeDto)
        {
            _recipeService.AddRecipe(recipeDto);
        }

        [HttpGet]
        public RecipeDto[] GetAll()
        {
            return _recipeRepository.GetAll();
        }

    }
}
