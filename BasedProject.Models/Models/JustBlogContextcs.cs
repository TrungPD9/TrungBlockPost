using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedProject.Models.Models
{
    public class JustBlogContext : DbContext
    {
        public JustBlogContext(DbContextOptions<JustBlogContext> options) 
            : base(options) { }

        public JustBlogContext() { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<PostTagMap> PostTagMaps { get; set; }       
        public DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-UDURVHV\\SQLEXPRESS;Initial Catalog=JustBlog;Integrated Security=True;Trust Server Certificate=True");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình mối quan hệ giữa Post và PostTagMap (Many-to-Many)
            modelBuilder.Entity<PostTagMap>()
                .HasKey(pt => new { pt.PostId, pt.TagId }); // Khóa chính composite

            modelBuilder.Entity<PostTagMap>()
                .HasOne(pt => pt.Post)  // Post liên kết với PostTagMap
                .WithMany(p => p.PostTagMap) // Post có nhiều PostTagMap
                .HasForeignKey(pt => pt.PostId) // Khóa ngoại từ PostTagMap đến Post
                .OnDelete(DeleteBehavior.Cascade); // Hành động xóa khi Post bị xóa

            modelBuilder.Entity<PostTagMap>()
                .HasOne(pt => pt.Tags)  // Tags liên kết với PostTagMap
                .WithMany(t => t.PostTagsmaps) // Tags có nhiều PostTagMap
                .HasForeignKey(pt => pt.TagId) // Khóa ngoại từ PostTagMap đến Tags
                .OnDelete(DeleteBehavior.Cascade); // Hành động xóa khi Tag bị xóa

            // Seed data cho bảng Category với đầy đủ các trường
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Technology", UrlSlug = "technology", Description = "Posts related to technology and programming" },
                new Category { Id = 2, Name = "Health", UrlSlug = "health", Description = "Posts about health, wellness, and fitness" },
                new Category { Id = 3, Name = "Lifestyle", UrlSlug = "lifestyle", Description = "Lifestyle and personal development posts" }
            );

            // Seed data cho bảng Tags
            modelBuilder.Entity<Tags>().HasData(
                new Tags { Id = 1, Name = "C#", UrlSlug = "csharp", Description = "Programming language", Count = 10 },
                new Tags { Id = 2, Name = "Health", UrlSlug = "health-tips", Description = "Health tips", Count = 8 },
                new Tags { Id = 3, Name = "Fitness", UrlSlug = "fitness", Description = "Fitness routines", Count = 12 }
            );

            // Seed data cho bảng Post
            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "Introduction to C#", ShortDescription = "Basic guide to C#", PostContent = "Content of the C# post", UrlSlug = "introduction-to-csharp", Published = true, PostedOn = DateTime.UtcNow, Modified = DateTime.UtcNow, CategoryId = 1 },
                new Post { Id = 2, Title = "Health Benefits of Yoga", ShortDescription = "Yoga benefits", PostContent = "Content about yoga health benefits", UrlSlug = "health-benefits-of-yoga", Published = true, PostedOn = DateTime.UtcNow, Modified = DateTime.UtcNow, CategoryId = 2 },
                new Post { Id = 3, Title = "10 Tips for a Better Lifestyle", ShortDescription = "Lifestyle tips", PostContent = "Content on improving lifestyle", UrlSlug = "10-tips-better-lifestyle", Published = true, PostedOn = DateTime.UtcNow, Modified = DateTime.UtcNow, CategoryId = 3 }
            );
        }
    }
}
