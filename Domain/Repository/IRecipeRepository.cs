using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repository
{
    public interface IRecipeRepository
    {
        void Add(Recipe recipe);
        Recipe GetById(int id);
        List<Recipe> GetAll();
        List<Recipe> GetByName(string nameofrecipe);
        List<Recipe> GetByFavorite();
        void DeleteRecipe(int id);
    }
}
