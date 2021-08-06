namespace Recipe_Api.Data.Dto
{
    public class StepDto
    {
        public int Id { get; set; }
        public string StepDescription { get; set; }
        public int RecipeId { get; set; }
    }
}
