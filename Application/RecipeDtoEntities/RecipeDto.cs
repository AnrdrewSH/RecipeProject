using System.Collections.Generic;

namespace Application.RecipeDtoEntities
{
    public class RecipeDto
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public int PersonNumber { get; set; }
        public int CookingTime { get; set; }
        public List<IngredientItemDto> IngredientItems { get; set; }
        public List<TagDto> Tags { get; set; }
        public List<StepDto> Steps { get; set; }
    }
}
