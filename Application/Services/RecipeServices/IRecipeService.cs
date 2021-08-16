using Domain.Entities;

namespace Application.Services.RecipeServices
{
    public interface IRecipeService
    {
        void DeleteRecipe();
        Recipe AddRecipe(Recipe recipeadd);
    }
}
