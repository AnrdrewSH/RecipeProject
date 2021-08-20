using Application.RecipeDtoEntities;
using Application.Services.Converters;
using Domain.Entities;
using Domain.Repository;

namespace Application.Services.RecipeServices
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public void AddRecipe(RecipeDto recipeDto)
        {
            Recipe recipe = FullRecipeConverter.ConvertToRecipe(recipeDto);
            _recipeRepository.Add(recipe);
        }

    }
}
