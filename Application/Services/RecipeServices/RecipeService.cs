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

        public void Update(RecipeDto recipeDto)
        {
            var recipe = _recipeRepository.GetById(recipeDto.RecipeId);
            var updatedRecipe = FullRecipeConverter.ConvertToRecipe(recipeDto);
            recipe.Update(updatedRecipe);
        }
    }
}
