using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Data.Enums;
using SocialMedia.Data.Models;
using System;
using System.Reflection.Emit;

namespace SocialMedia.Data.Data
{
    public class AppDbContext : IdentityDbContext<User, ApplicationRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure the Post entity
            builder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.PostId);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.UpdatedAt).IsRequired();
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Posts)
                      .HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.Comments)
                      .WithOne(c => c.Post)
                      .HasForeignKey(c => c.PostId);
                entity.HasMany(e => e.Likes)
                      .WithOne(l => l.Post)
                      .HasForeignKey(l => l.PostId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure the Comment entity
            builder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.CommentId);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Comments)
                      .HasForeignKey(e => e.Author)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Post)
                      .WithMany(p => p.Comments)
                      .HasForeignKey(e => e.PostId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure the Like entity
            builder.Entity<Like>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PostId });
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Post)
                      .WithMany(p => p.Likes)
                      .HasForeignKey(e => e.PostId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure the User entity
            builder.Entity<User>(entity =>
            {
                entity.HasMany(u => u.Posts)
                      .WithOne(p => p.User)
                      .HasForeignKey(p => p.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.Comments)
                      .WithOne(c => c.User)
                      .HasForeignKey(c => c.Author)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Message>()
                .HasOne(m => m.SenderUser)
                .WithMany()
                .HasForeignKey(m => m.SenderUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(m => m.ReceiverUser)
                .WithMany()
                .HasForeignKey(m => m.ReceiverUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(m => m.Chat)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChatId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data
            /*var userId = Guid.NewGuid();
            var hasher = new PasswordHasher<User>();

            builder.Entity<User>().HasData(
                new User
                {
                    Id = userId,
                    UserName = "defaultuser",
                    NormalizedUserName = "DEFAULTUSER",
                    Email = "defaultuser@example.com",
                    NormalizedEmail = "DEFAULTUSER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Password123!"),
                    SecurityStamp = string.Empty,
                    FirstName = "Default",
                    LastName = "User",
                    Age = 25,
                    Bio = "This is a default user.",
                    City = "Default City",
                    Country = "Default Country",
                    ProfileImageUrl = null,
                    CoverImageUrl = null,
                    BirthDay = new DateTime(1998, 1, 1),
                    Gender = Gender.male
                }
            );*/

        }
    }
}
