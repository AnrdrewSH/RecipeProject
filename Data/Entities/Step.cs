namespace Recipe_Api.Data.Entities
{
    public class Step
    {
        public int Id { get; }
        public string StepDescription { get; set; }
        public int RecipeId { get; set; }

    }
}
