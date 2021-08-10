using Recipe_Api.Data.Entities;

namespace Recipe_Api.Data.Interfaces
{
    public interface IRecipeRepository
    {
        void Add(Recipe recipe);
    }
}
