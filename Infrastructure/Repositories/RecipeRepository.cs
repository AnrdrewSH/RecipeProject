using Application;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private AppDbContext _context;
        private IUnitOfWork _unitOfWork;

        public RecipeRepository(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public void Add(Recipe newRecipe)
        {
            _context.Set<Recipe>().Add(newRecipe);
            _unitOfWork.Commit();
        }

        public RecipeDto[] GetAll()
        {
            return _context.Set<Recipe>().ToList()
                .ConvertAll(x => new RecipeDto {RecipeId = x.RecipeId, RecipeName = x.RecipeName, RecipeDescription = x.RecipeDescription, PersonNumber = x.PersonNumber, CookingTime = x.CookingTime, Tags = x.Tags, Steps = x.Steps, IngredientItems = x.IngredientItems })
                .ToArray();
        }

        public Recipe GetById(int id)
        {
            return _context.Set<Recipe>().Include(item => item.Tags).FirstOrDefault(x => x.RecipeId == id);
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
