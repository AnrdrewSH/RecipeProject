using Recipe_Api.Data.Dto;
using Recipe_Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_Api.test_commands
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
        public static RecipeDto ConvertToRecipeDto(this Recipe recipe)
        {
            return new RecipeDto
            {
                RecipeId = recipe.RecipeId,
                RecipeName = recipe.RecipeName,
                RecipeDescription = recipe.RecipeDescription,
                CookingTime = recipe.CookingTime,
                PersonNumber = recipe.PersonNumber,
                Likes = recipe.Likes,
                Stars = recipe.Stars,
                Tags = recipe.Tags.Select(x => x.Name).ToList()
            };
        }
    }
}
