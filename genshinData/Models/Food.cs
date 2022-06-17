namespace genshinData.Models
{
    public class Food
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Rarity { get; set; }
        public string? ImagePath { get; set; }
    }
}
