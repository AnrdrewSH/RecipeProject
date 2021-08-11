using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private AppDbContext _context;

        public RecipeRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Recipe newRecipe)
        {
            _context.Set<Recipe>().Add(newRecipe);
        }

        public void GetById(int id)
        {
            _context.Set<Recipe>().Include(item => item.Tags).Where(item => item.RecipeId == id);
        }

    }
}
