namespace Domain.Entities
{
    public class IngredientItem
    {
        public int Id { get; }
        public string IngredientItemName { get; set; }
        public string Products { get; set; }
        public int RecipeId { get; set; }
    }
}