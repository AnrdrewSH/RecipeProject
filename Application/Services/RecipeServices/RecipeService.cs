using Domain.Entities;
using Domain.Interfaces;
using System.Linq;

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

        public void AddRecipe(RecipeDto recipeDto)
        {
            Recipe recipe = ConvertToRecipe(recipeDto);
            _recipeRepository.Add(recipe);
        }

        private static Recipe ConvertToRecipe(RecipeDto recipeDto)
        {
            return new Recipe
            {
                RecipeName = recipeDto.RecipeName,
                RecipeDescription = recipeDto.RecipeDescription,
                PersonNumber = recipeDto.PersonNumber,
                CookingTime = recipeDto.CookingTime,
                Tags = recipeDto.Tags.Select(x => new Tag { Name = x.Name, RecipeId = x.RecipeId }).ToList(),
                IngredientItems = recipeDto.IngredientItems.Select(x => new IngredientItem { IngredientItemName = x.IngredientItemName, Products = x.Products, RecipeId = x.RecipeId }).ToList(),
                Steps = recipeDto.Steps.Select(x => new Step { StepDescription = x.StepDescription, RecipeId = x.RecipeId }).ToList(),
            };
        }

    }
}
