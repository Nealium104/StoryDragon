using StoryDragon.Models;
using Microsoft.EntityFrameworkCore;

namespace StoryDragon.Data
{
    public class StoryDragonContext : DbContext
    {
        public DbSet<Story> Stories { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        public string DbPath { get; }

        public StoryDragonContext() 
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "storyDragon.db");
        }

        // The following configures EF to createa Sqlite database file in the special "local" folder for your platform
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Story>()
                .HasMany(s => s.Characters)
                .WithMany(c => c.Stories)
                .UsingEntity(j => j.ToTable("StoryCharacters"));
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Stories)
                .WithMany(s => s.Posts)
                .UsingEntity(j => j.ToTable("PostStories"));
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Characters)
                .WithMany(c => c.Posts)
                .UsingEntity(j => j.ToTable("PostCharacters"));
            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne()
                .HasForeignKey(p => p.UserId);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Characters)
                .WithOne()
                .HasForeignKey(c => c.UserId);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Stories)
                .WithOne()
                .HasForeignKey(s => s.UserId);
        }
    }
}