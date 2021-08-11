using Application.Services.Entities;
using Domain.Entities;

namespace Application.Services.RecipeServices
{

    public interface IRecipeService
    {
        void DeleteRecipe();
        Recipe AddRecipe(AddRecipeCommand addCommand);
    }

}
