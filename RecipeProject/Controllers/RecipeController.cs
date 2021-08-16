using Application;
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

        public RecipeController(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork, IRecipeService recipeService)
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
            _recipeService = recipeService;
        }

        [HttpGet("{id:int}")]
        public Recipe GetRecipeById(int id)
        {
            Recipe recipe = _recipeRepository.GetById(id);
            return recipe;
        }

        [HttpPost]
        public void AddRecipe(Recipe value)
        {
            _recipeService.AddRecipe(value);
            _unitOfWork.Commit();
        }

        [HttpGet]
        public Recipe[] Get()
        {
            return _recipeRepository.GetAll();
        }

    }
}
