using Microsoft.EntityFrameworkCore;
using Twitter.Domain.Models;

namespace Twitter.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User -> Tweets (One-to-Many) with Cascade Delete
            modelBuilder.Entity<Tweet>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tweets)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade); // If a user is deleted, delete their tweets

            // Tweet -> Comments (One-to-Many) with Cascade Delete
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Tweet)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TweetId)
                .OnDelete(DeleteBehavior.Cascade); // If a tweet is deleted, delete its comments

            // User -> Comments (One-to-Many) WITHOUT Cascade Delete
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); // No cascade delete, user deletion doesn't affect comments

            // Seed data
            var user1Id = Guid.NewGuid();
            var user2Id = Guid.NewGuid();
            var tweet1Id = Guid.NewGuid();
            var tweet2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User { Id = user1Id, Name = "John Doe", Email = "john@example.com", Password = "password1", Phone = "1234567890" },
                new User { Id = user2Id, Name = "Jane Smith", Email = "jane@example.com", Password = "password2", Phone = "0987654321" }
            );

            modelBuilder.Entity<Tweet>().HasData(
                new Tweet { Id = tweet1Id, Text = "Hello, world!", CreatedAt = DateTime.Now, UserId = user1Id },
                new Tweet { Id = tweet2Id, Text = "Learning EF Core!", CreatedAt = DateTime.Now, UserId = user2Id }
            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = Guid.NewGuid(), Text = "Great tweet!", TweetId = tweet1Id, UserId = user2Id },
                new Comment { Id = Guid.NewGuid(), Text = "Thanks for the info!", TweetId = tweet2Id, UserId = user1Id }
            );
        }
    }
}
