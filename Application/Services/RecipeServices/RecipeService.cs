using Application.Services.Entities;
using Domain.Entities;
using Domain.Interfaces;
using Recipe_Api;

namespace Application.Services.RecipeServices
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public void DeleteRecipe()
        {
        }

        public Recipe AddRecipe(AddRecipeCommand addCommand)
        {
            var recipe = addCommand.Convert();
            _recipeRepository.Add(recipe);
            return recipe;
        }
    }
}
