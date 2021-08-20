using Application.RecipeDtoEntities;
using Domain.Entities;
using System.Linq;

namespace Application.Services.Converters
{
    public interface IRecipeDtoConverter
    {
        RecipeDto ConvertToRecipeDto( Recipe recipe );
    }

    public class RecipeDtoConverter : IRecipeDtoConverter
    {
        public RecipeDto ConvertToRecipeDto( Recipe recipe )
        {
            return new RecipeDto
            {
                RecipeName = recipe.RecipeName,
                RecipeDescription = recipe.RecipeDescription,
                PersonNumber = recipe.PersonNumber,
                CookingTime = recipe.CookingTime,
                Tags = recipe.Tags
                    .Select( x => new TagDto
                    {
                        Name = x.Name
                    } ).ToList(),
                IngredientItems = recipe.IngredientItems
                    .Select( x => new IngredientItemDto
                    {
                        IngredientItemName = x.IngredientItemName,
                        Products = x.Products,
                        RecipeId = x.RecipeId
                    } ).ToList(),
                Steps = recipe.Steps
                    .Select( x => new StepDto
                    {
                        StepDescription = x.StepDescription,
                        RecipeId = x.RecipeId
                    } ).ToList()
            };
        }
    }
}
