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

        public Recipe[] GetAll()
        {
            return _context.Set<Recipe>().ToList()
                .ConvertAll(x => new Recipe { RecipeId = x.RecipeId, RecipeName = x.RecipeName, RecipeDescription = x.RecipeDescription, PersonNumber = x.PersonNumber, CookingTime = x.CookingTime, Tags = x.Tags, Steps = x.Steps, IngredientItems = x.IngredientItems})
                .ToArray();
        }

        public Recipe GetById(int id)
        {
            return GetQuery().FirstOrDefault(x => x.RecipeId == id);
        }

        private IQueryable<Recipe> GetQuery()
        {
            return _context.Set<Recipe>()
                .Include(x => x.Tags)
                .Include(x => x.Steps)
                .Include(x => x.IngredientItems)
                .AsQueryable();
        }

    }
}
