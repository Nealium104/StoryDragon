namespace StoryDragon.Models
{
    public class Story
    {
        public Guid StoryID { get; set; } = Guid.NewGuid();
        public string StoryTitle { get; set; }
        public string StoryDescription { get; set; }
        public string StoryText { get; set; }
    }
}
