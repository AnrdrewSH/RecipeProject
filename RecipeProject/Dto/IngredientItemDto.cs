namespace RecipeApi.Data.Dto
{
    public class IngredientItemDto
    {
        public int Id { get; set; }
        public string IngredientItemName { get; set; }
        public int RecipeId { get; set; }
        public string Products { get; set; }
    }
}
