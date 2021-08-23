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

        public void Update(int id, Recipe recipe)
        {
            Recipe newRecipe = _context.Set<Recipe>().FirstOrDefault(item => item.RecipeId == id);
            newRecipe.RecipeName = recipe.RecipeName;
            newRecipe.RecipeDescription = recipe.RecipeDescription;
            newRecipe.PersonNumber = recipe.PersonNumber;
            newRecipe.CookingTime = recipe.CookingTime;
            newRecipe.Tags = recipe.Tags;
            newRecipe.Steps = recipe.Steps;
            newRecipe.IngredientItems = recipe.IngredientItems;
        }

        public List<Recipe> GetAll()
        {
            return _context.Set<Recipe>()
                .Include(item => item.Tags)
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
