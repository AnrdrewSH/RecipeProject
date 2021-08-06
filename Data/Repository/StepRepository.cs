using Recipe_Api.Data.Dto;
using Recipe_Api.Data.Entities;
using Recipe_Api.Data.Interfaces;
using Recipe_Api.Dblnfrastructure;
using System.Linq;

namespace Recipe_Api.Data.Repository
{
    public class StepRepository : IStepRepository
    {
        private AppDbContext _context;
        private IUnitOfWork _unitOfWork;
        public StepRepository(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public StepDto[] GetAllSteps()
        {
            return _context.Set<Step>().ToList()
                .ConvertAll(x => new StepDto { Id = x.Id, StepDescription = x.StepDescription, RecipeId = x.RecipeId })
                .ToArray();
        }
        public int Add(StepDto stepDto)
        {
            Step newStep = new Step
            {
                StepDescription = stepDto.StepDescription,
                RecipeId = stepDto.RecipeId,
            };
            _context.Set<Step>().Add(newStep);
            _unitOfWork.Commit();

            return newStep.Id;
        }
    }

}
