namespace MicroLearn.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int DomainId { get; set; }
        public Domain Domain { get; set; } = null!;
    }
}
