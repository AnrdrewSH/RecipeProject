using Recipe_Api.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_Api.Data.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private AppDbContext _context;
        public RecipeRepository(AppDbContext context)
        {
            _context = context;
        }
        public int GetRecipeId()
        {
            return _context.Steps.Max(c => c.RecipeId);
        }
    }
}
