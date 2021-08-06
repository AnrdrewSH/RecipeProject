using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_Api.Data.Dto
{
    public class IngredientItemDto
    {
        public int Id { get; set; }
        public string IngredientItemName { get; set; }
        public int RecipeId { get; set; }
        public string Products { get; set; }
    }
}
