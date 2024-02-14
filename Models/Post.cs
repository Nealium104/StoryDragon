using StoryDragon.Classes;

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
        public PostTypeEnum? PostType { get; set; }
        public ICollection<Character>? Characters { get; set; } = new List<Character>();
        public ICollection<Story>? Stories { get; set; } = new List<Story>();
    }
}
