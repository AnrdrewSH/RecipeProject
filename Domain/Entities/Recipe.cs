using System.Collections.Generic;

namespace Domain.Entities
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public int PersonNumber { get; set; }
        public int CookingTime { get; set; }
        public int Likes { get; set; }
        public int Stars { get; set; }
        public List<IngredientItem> IngredientItems { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Step> Steps { get; set; }

        public void Update(Recipe recipe)
        {
            RecipeName = recipe.RecipeName;
            RecipeDescription = recipe.RecipeDescription;
            PersonNumber = recipe.PersonNumber;
            CookingTime = recipe.CookingTime;
            Likes = recipe.Likes;
            Stars = recipe.Stars;
            IngredientItems = recipe.IngredientItems;
            Tags = recipe.Tags;
            Steps = recipe.Steps;
        }
    }
    
}
