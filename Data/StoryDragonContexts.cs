using Microsoft.EntityFrameworkCore;
using StoryDragon.Models;
using System;

namespace StoryDragon.Data
{
    public class StoryDragonContext : DbContext
    {
        public DbSet<Story> Stories { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        public StoryDragonContext(DbContextOptions<StoryDragonContext> options) : base(options)
        {
        }

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
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Stories)
                .WithOne()
                .HasForeignKey(s => s.UserId);
        }
    }
}