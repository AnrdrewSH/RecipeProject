using Application;
using Application.Services.RecipeServices;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Application.Services.RecipeServices.RecipeService;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeService _recipeService;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeController(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork, IRecipeService recipeService)
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
            _recipeService = recipeService;
        }

        [HttpGet("{id:int}")]
        public Recipe GetRecipe(int id)
        {
            Recipe recipe = _recipeRepository.GetById(id);
            return recipe;
        }

        [HttpPost]
        public void AddRecipe(TempRecipeDto value)
        {
            _recipeService.AddRecipe(value);
            _unitOfWork.Commit();
        }

    }
}
