using Application.Services.Entities;
using Domain.Entities;
using System.Linq;

namespace Recipe_Api
{
    public static class RecipeConverter
    {
        public static Recipe Convert(this AddRecipeCommand addRecipeDto)
        {
            return new Recipe
            {
                RecipeName = addRecipeDto.RecipeName,
                RecipeDescription = addRecipeDto.RecipeDescription,
                CookingTime = addRecipeDto.CookingTime,
                PersonNumber = addRecipeDto.PersonNumber,
                Tags = addRecipeDto.Tags.Select(x => new Tag
                {
                    Name = x
                }).ToList(),
                Steps = addRecipeDto.Steps.Select(x => new Step
                {
                    StepDescription = x
                }).ToList(),
                IngredientItems = addRecipeDto.IngredientItems.Select(x => new IngredientItem
                {
                    IngredientItemName = x,
                    Products = x

                }).ToList()
            };
        }

    }
}
