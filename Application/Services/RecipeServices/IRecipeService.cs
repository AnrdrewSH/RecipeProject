using Domain.Entities;

namespace Application.Services.RecipeServices
{
    public interface IRecipeService
    {
        void AddRecipe(FullRecipeDto recipeDto);
    }
}
