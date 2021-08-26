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

        public List<Recipe> GetAllRecipeByTag(string nameoftag)
        {
            return _context.Set<Recipe>()
                .Include(item => item.Tags.FirstOrDefault(x => x.Name == nameoftag))
                .Include(item => item.Steps)
                .Include(item => item.IngredientItems)
                .ToList();
        }

        public Recipe GetById( int id )
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
