using Microsoft.EntityFrameworkCore;
using Recipe_Api.Data.Dto;
using Recipe_Api.Data.Entities;
using Recipe_Api.Data.Interfaces;
using Recipe_Api.Dblnfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        //private IQueryable<Recipe> GetQuery()
        //{
        //    return _context.Set<Recipe>()
        //        //.Include(x => x.Tags)
        //        .Include(x => x.Steps)
        //        //.Include(x => x.Ingredients)
        //        .AsQueryable();
        //}
    }
}
