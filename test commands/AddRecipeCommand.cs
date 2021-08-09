using Recipe_Api.Data.Dto;
using Recipe_Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

