using BasedProject.DataAccess.IRepositories;
using BasedProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedProject.DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly JustBlogContext _context = new JustBlogContext();

        public PostRepository(JustBlogContext context)
        {
            _context = _context;
        }
        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public int CountPostsForCategory(string category)
        {
            return _context.Posts.Count(p => p.Category != null && p.Category.Name == category);
        }

        public void DeletePost(Post post)
        {
            _context?.Remove(post);
            _context?.SaveChanges();
        }

        public void DeletePost(int postId)
        {
            var post = _context.Posts.Find(postId);
            if(post != null)
            {
                _context?.Remove(post);
                _context?.SaveChanges();
            }
            
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            return _context.Posts.Find(year, month, urlSlug);
        }

        public Post FindPost(int postId)
        {
            return _context.Posts.Find(postId);
        }

        public IList<Post> GetAllPosts()
        {
            return _context.Posts.ToList();
        }

        public IList<Post> GetLatestPost(int size)
        {
            return _context.Posts.OrderByDescending(p => p.PostedOn).Take(size).ToList();
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            return _context.Posts.Where(p => p.Category.Name == category).ToList();
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return _context.Posts.Where(p => p.PostedOn.Month == monthYear.Month && p.PostedOn.Year == monthYear.Year).ToList();
        }

        public IList<Post> GetPublisedPosts()
        {
            return _context.Posts.Where(p => p.Published).ToList();
        }

        public IList<Post> GetUnpublisedPosts()
        {
            return _context.Posts.Where(p => !p.Published).ToList();
        }

        public void UpdatePost(Post post)
        {
            var existingPost = _context.Posts.Find(post.Id);
            if (existingPost != null)
            {
                existingPost.Title = post.Title;
                existingPost.ShortDescription = post.ShortDescription;
                existingPost.PostContent = post.PostContent;
                existingPost.UrlSlug = post.UrlSlug;
                existingPost.Published = post.Published;
                existingPost.PostedOn = post.PostedOn;
                existingPost.Modified = post.Modified;
            }
        }
    }
}
