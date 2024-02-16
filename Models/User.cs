namespace StoryDragon.Models
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string Bio { get; set; }
        public ICollection<Character> Characters { get; set; } = new List<Character>();
        public ICollection<Story> Stories { get; set; } = new List<Story>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
