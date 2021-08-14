using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;

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

        public Recipe AddRecipe(TempRecipeDto recipeDto)
        {
            Recipe recipe = new Recipe
            {
                RecipeId = recipeDto.RecipeId,
                RecipeName = recipeDto.RecipeName,
                RecipeDescription = recipeDto.RecipeDescription,
                PersonNumber = recipeDto.PersonNumber,
                CookingTime = recipeDto.CookingTime,
                Tags = recipeDto.Tags,
                IngredientItems = recipeDto.IngredientItems,
                Steps = recipeDto.Steps
            };
            _recipeRepository.Add(recipe);
            return recipe;
        }

        public class TempRecipeDto
        {
            public int RecipeId { get; set; }
            public string RecipeName { get; set; }
            public string RecipeDescription { get; set; }
            public int PersonNumber { get; set; }
            public int CookingTime { get; set; }
            public List<Tag> Tags { get; set; }
            public List<IngredientItem> IngredientItems { get; set; }
            public List<Step> Steps { get; set; }
        }

    }
}
