﻿namespace StoryDragon.Models
{
    public class Story
    {
        public Guid StoryID { get; set; } = Guid.NewGuid();
        public string StoryTitle { get; set; }
        public string StoryDescription { get; set; }
        public string StoryText { get; set; }
        public Guid UserId { get; set; }
        public ICollection<Character> Characters { get; set;} = new List<Character>();
        public ICollection<Post> Posts { get; set;} = new List<Post>();
    }
}