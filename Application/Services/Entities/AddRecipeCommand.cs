using System.Collections.Generic;

namespace Application.Services.Entities
{
    public class AddRecipeCommand
    {
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public int PersonNumber { get; set; }
        public int CookingTime { get; set; }
        public List<string> IngredientItems { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Steps { get; set; }
    }
}
