using Application.Services.Converters;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.RecipeServices
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public void AddRecipe(FullRecipeDto recipeDto)
        {
            FullRecipe recipe = FullRecipeConverter.ConvertToRecipe(recipeDto);
            _recipeRepository.Add(recipe);
        }

    }
}
