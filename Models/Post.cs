namespace StoryDragon.Models
{
    public class Post
    {
        public Guid PostId { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string PostText { get; set; }
        public DateTime PostDate { get; set; }
        public int Likes { get; set; }
        public DateTime? EditDate { get; set; }

    }
}
