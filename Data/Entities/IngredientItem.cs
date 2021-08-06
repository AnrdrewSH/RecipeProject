using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe_Api.Data.Entities
{
    public class IngredientItem
    {
        public int Id { get; }
        public string IngredientItemName { get; set; }
        public int RecipeId { get; set; }
        public string Products { get; set; }
    }
}