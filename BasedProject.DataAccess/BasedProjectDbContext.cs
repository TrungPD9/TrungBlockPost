using BasedProject.Models;
using BasedProject.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BasedProject.DataAccess
{
    public class BasedProjectDbContext : DbContext
    {
        public BasedProjectDbContext()
        {
            
        }

        public BasedProjectDbContext(DbContextOptions<BasedProjectDbContext> options) : base(options)
        {
            
        }

        //set DbSet<Entity>
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Tags>? Tags { get; set; }
        public DbSet<PostTagMap>? PostTagMaps { get; set; }
        public DbSet<Comment>? Comments { get; set; }
    }
}/**/
