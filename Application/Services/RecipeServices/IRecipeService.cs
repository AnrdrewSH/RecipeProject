using Domain.Entities;
using static Application.Services.RecipeServices.RecipeService;

namespace Application.Services.RecipeServices
{
    public interface IRecipeService
    {
        void DeleteRecipe();
        Recipe AddRecipe(TempRecipeDto recipeDto);
    }
}
