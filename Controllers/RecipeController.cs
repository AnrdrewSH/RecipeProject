using Application;
using Application.Services.Entities;
using Application.Services.RecipeServices;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Recipe_Api.Controllers
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

        [HttpPost]

        public int AddRecipe()
        {
            var newRecipe = _recipeService.AddRecipe(new AddRecipeCommand());
            _unitOfWork.Commit();
            return newRecipe.RecipeId;
        }

    }
}
