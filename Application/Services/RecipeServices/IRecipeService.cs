using Application.RecipeDtoEntities;

namespace Application.Services.RecipeServices
{
    public interface IRecipeService
    {
        void AddRecipe(RecipeDto recipeDto);
        void Update(RecipeDto recipeDto);
    }
}
