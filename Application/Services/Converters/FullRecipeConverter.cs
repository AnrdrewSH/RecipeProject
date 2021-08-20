using Domain.Entities;
using System.Linq;
using Application.RecipeDtoEntities;

namespace Application.Services.Converters
{
    public class FullRecipeConverter
    {
        public static Recipe ConvertToRecipe( RecipeDto recipeDto )
        {
            return new Recipe
            {
                RecipeName = recipeDto.RecipeName,
                RecipeDescription = recipeDto.RecipeDescription,
                PersonNumber = recipeDto.PersonNumber,
                CookingTime = recipeDto.CookingTime,
                Tags = recipeDto.Tags.Select( x => new Tag { Name = x.Name, RecipeId = recipeDto.RecipeId } ).ToList(),
                IngredientItems = recipeDto.IngredientItems.Select( x => new IngredientItem { IngredientItemName = x.IngredientItemName, Products = x.Products, RecipeId = x.RecipeId } ).ToList(),
                Steps = recipeDto.Steps.Select( x => new Step { StepDescription = x.StepDescription, RecipeId = x.RecipeId } ).ToList(),
            };
        }
    }
}
