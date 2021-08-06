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
    public class IngredientItemRepository : IIngredientItemRepository
    {
        private AppDbContext _context;
        private IUnitOfWork _unitOfWork;
        public IngredientItemRepository(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;

        }
        public IngredientItemDto[] GetAllIngredientItems()
        {
            return _context.Set<IngredientItem>().ToList()
                .ConvertAll(x => new IngredientItemDto { Id = x.Id, IngredientItemName = x.IngredientItemName, Products = x.Products, RecipeId = x.RecipeId })
                .ToArray();
        }
        public int Add(IngredientItemDto IngredientItemDto)
        {
            IngredientItem newIngredientItem = new IngredientItem
            {
                Products = IngredientItemDto.Products,
                IngredientItemName = IngredientItemDto.IngredientItemName,
                RecipeId = IngredientItemDto.RecipeId,
            };
            _context.Set<IngredientItem>().Add(newIngredientItem);
            _unitOfWork.Commit();

            return newIngredientItem.Id;
        }
    }
}
