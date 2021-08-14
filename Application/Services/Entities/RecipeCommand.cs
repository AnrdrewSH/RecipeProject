using System.Collections.Generic;

namespace Application.Services.Entities
{
    public class RecipeCommand
    {
        public RecipeCommand(int id,
        string name, string description, int personNumber, int cookingTime, List<string> ingredientItems, List<string> steps, List<string> tags)
        {
            RecipeId = id;
            RecipeName = name;
            RecipeDescription = description;
            PersonNumber = personNumber;
            CookingTime = cookingTime;
            Tags = tags;
            Steps = steps;
            IngredientItems = ingredientItems;
        }
            
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public int PersonNumber { get; set; }
        public int CookingTime { get; set; }
        public List<string> IngredientItems { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Steps { get; set; }
    }
}
