namespace StoryDragon.Models
{
    public class Character
    {
        public Guid CharacterId { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string CharacterName { get; set; }
        public string CharacterShortDescription { get; set; }
        public string CharacterDescription { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public ICollection<Story> Stories { get; set; } = new List<Story>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
