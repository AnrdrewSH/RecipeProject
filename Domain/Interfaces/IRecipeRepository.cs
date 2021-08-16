using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRecipeRepository
    {
        void Add(Recipe recipe);
        Recipe GetById(int id);
        Recipe[] GetAll();
    }
}
