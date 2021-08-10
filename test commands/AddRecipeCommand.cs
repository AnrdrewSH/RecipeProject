using System.Collections.Generic;

namespace Recipe_Api.test_commands
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

