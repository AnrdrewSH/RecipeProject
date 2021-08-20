using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRecipeRepository
    {
        void Add(FullRecipe recipe);
        FullRecipe GetById(int id);
        FullRecipe[] GetAllFullRecipe();
    }
}
