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

        public void Add(FullRecipe newRecipe)
        {
            _context.Set<FullRecipe>().Add(newRecipe);
        }

        public FullRecipe[] GetAllFullRecipe()
        {
            return _context.Set<FullRecipe>().ToList()
                .ConvertAll(x => new FullRecipe
                {
                    RecipeName = x.RecipeName,
                    RecipeDescription = x.RecipeDescription,
                    PersonNumber = x.PersonNumber,
                    CookingTime = x.CookingTime,
                    Tags = x.Tags,
                    Steps = x.Steps,
                    IngredientItems = x.IngredientItems
                })
                .ToArray();
        }

        public FullRecipe GetById(int id)
        {
            return _context.Set<FullRecipe>().Include(item => item.Tags).FirstOrDefault(x => x.RecipeId == id);
        }

    }
}
