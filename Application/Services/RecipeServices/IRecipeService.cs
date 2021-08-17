using Domain.Entities;

namespace Application.Services.RecipeServices
{
    public interface IRecipeService
    {
        void DeleteRecipe();
        void AddRecipe(RecipeDto recipeDto);
    }
}
