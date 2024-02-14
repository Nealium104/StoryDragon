namespace StoryDragon.Models
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string Bio { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
