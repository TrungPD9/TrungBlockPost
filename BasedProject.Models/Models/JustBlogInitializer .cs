using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedProject.Models.Models
{
    public class JustBlogInitializer
    {
        public static void Initialize(JustBlogContext context)
        {
            // Thực hiện migrate cơ sở dữ liệu nếu chưa được tạo
            context.Database.Migrate();

            // Kiểm tra và thêm dữ liệu mẫu nếu chưa có
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { Name = "Technology", Description = "Technology related posts" },
                    new Category { Name = "Health", Description = "Health and wellness posts" },
                    new Category { Name = "Lifestyle", Description = "Lifestyle related posts" }
                );
            }

            if (!context.Tags.Any())
            {
                context.Tags.AddRange(
                    new Tags { Name = "C#", Description = "Programming language", Count = 10 },
                    new Tags { Name = "Health", Description = "Health tips", Count = 8 },
                    new Tags { Name = "Fitness", Description = "Fitness routines", Count = 12 }
                );
            }

            if (!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post { Title = "Introduction to C#", PostedOn = DateTime.Now, Published = true, CategoryId = 1 },
                    new Post { Title = "Health Benefits of Yoga", PostedOn = DateTime.Now, Published = true, CategoryId = 2 },
                    new Post { Title = "10 Tips for a Better Lifestyle", PostedOn = DateTime.Now, Published = true, CategoryId = 3 }
                );
            }

            // Lưu dữ liệu vào cơ sở dữ liệu
            context.SaveChanges();
        }
    }
}
