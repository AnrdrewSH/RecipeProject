using Domain.Entities;
using System.Linq;

namespace Application.Services.Converters
{
    public class FullRecipeConverter
    {
        public static FullRecipe ConvertToRecipe(FullRecipeDto recipeDto)
        {
            return new FullRecipe
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
