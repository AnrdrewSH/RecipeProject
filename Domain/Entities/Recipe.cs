using System.Collections.Generic;

namespace Domain.Entities
{
    public class Recipe
    {
        public int RecipeId { get; }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public int PersonNumber { get; set; }
        public int CookingTime { get; set; }
        public List<IngredientItem> IngredientItems { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Step> Steps { get; set; }
        public int Likes { get; set; }
        public int Stars { get; set; }
    }
}
