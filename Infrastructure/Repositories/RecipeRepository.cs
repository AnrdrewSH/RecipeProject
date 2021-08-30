using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private AppDbContext _context;

        public RecipeRepository( AppDbContext context )
        {
            _context = context;
        }

        public void Add( Recipe newRecipe )
        {
            _context.Set<Recipe>().Add( newRecipe );
        }

        public void DeleteRecipe(int id)
        {
            Recipe recipe = GetById(id);
            _context.Set<Recipe>().Remove(recipe);
        }

        public List<Recipe> GetAll()
        {
            return _context.Set<Recipe>()
                .Include(item => item.Tags)
                .Include(item => item.Steps)
                .Include(item => item.IngredientItems)
                .ToList();
        }

        public List<Recipe> GetByName(string nameofrecipe)
        {
            return _context.Set<Recipe>().Where(item => item.RecipeName == nameofrecipe)
                .Include(item => item.Tags)
                .Include(item => item.Steps)
                .Include(item => item.IngredientItems)
                .ToList();
        }

        public Recipe GetById( int id )
        {
            return _context.Set<Recipe>()
                .Include(item => item.Tags)
                .Include(item => item.Steps)
                .Include(item => item.IngredientItems)
                .FirstOrDefault(x => x.RecipeId == id);
        }

        public List<Recipe> GetByFavorite()
        {
            return _context.Set<Recipe>().Where(item => item.Stars == 1)
                .Include(item => item.Tags)
                .Include(item => item.Steps)
                .Include(item => item.IngredientItems)
                .ToList();
        }

    }
}
