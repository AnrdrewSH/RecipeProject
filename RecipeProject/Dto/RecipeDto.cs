using Domain.Entities;
using System.Collections.Generic;

namespace RecipeApi.Data.Dto
{
    public class RecipeDto
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
