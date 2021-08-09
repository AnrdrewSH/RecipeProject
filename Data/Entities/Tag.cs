namespace Recipe_Api.Data.Entities
{
    public class Tag
    {
        public int Id { get; }
        public string Name { get; set; }
        public int RecipeId { get; set; }
        
    }
}
