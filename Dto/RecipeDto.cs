using Domain.Entities;
using System.Collections.Generic;

namespace Recipe_Api.Data.Dto
{
    public class RecipeDto
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public int PersonNumber { get; set; }
        public int CookingTime { get; set; }
        public List<string> Tags { get; set; }
        public int Likes { get; set; }
        public int Stars { get; set; }
        public List<IngredientItem> IngredientItems { get; set; }
        public List<Step> Steps { get; set; }
    }
}
