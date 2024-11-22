using BasedProject.DataAccess.IRepositories;
using BasedProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedProject.DataAccess.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly JustBlogContext _context;

        public CommentRepository(JustBlogContext context)
        {
            _context = context;
        }
        public void AddComment(Comment comment)
        {
           _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(int commendId)
        {
            throw new NotImplementedException();
        }

        public Comment Find(int commentId)
        {
            throw new NotImplementedException();
        }

        public IList<Comment> GetAllComments()
        {
            throw new NotImplementedException();
        }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            throw new NotImplementedException();
        }

        public IList<Comment> GetCommentsForPost(Post post)
        {
            throw new NotImplementedException();
        }

        public void UpdateComment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
