using Domain.Entities;
using System.Linq;

namespace Application.Services.Converters
{
    public class FullRecipeDtoConverter
    {
        public static FullRecipeDto ConvertToRecipeDto(FullRecipe recipe)
        {
            return new FullRecipeDto
            {
                RecipeName = recipe.RecipeName,
                RecipeDescription = recipe.RecipeDescription,
                PersonNumber = recipe.PersonNumber,
                CookingTime = recipe.CookingTime,
                Tags = recipe.Tags.Select(x => new Tag { Name = x.Name, RecipeId = x.RecipeId }).ToList(),
                IngredientItems = recipe.IngredientItems.Select(x => new IngredientItem { IngredientItemName = x.IngredientItemName, Products = x.Products, RecipeId = x.RecipeId }).ToList(),
                Steps = recipe.Steps.Select(x => new Step { StepDescription = x.StepDescription, RecipeId = x.RecipeId }).ToList(),
            };
        }
    }
}
