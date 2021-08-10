using Recipe_Api.Data.Entities;

namespace Recipe_Api.test_commands
{
    public interface IRecipeService
    {
        void DeleteRecipe();
        Recipe AddRecipe(AddRecipeCommand addCommand);
    }
}
