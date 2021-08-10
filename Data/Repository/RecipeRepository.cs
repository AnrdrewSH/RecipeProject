using Microsoft.EntityFrameworkCore;
using Recipe_Api.Data.Entities;
using Recipe_Api.Data.Interfaces;
using Recipe_Api.Dblnfrastructure;
using System.Linq;

namespace Recipe_Api.Data.Repository
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
        }
        public void GetById(int id)
        {
            _context.Set<Recipe>().Include(item => item.Tags).Where(item => item.RecipeId == id);
        }
    }
}
