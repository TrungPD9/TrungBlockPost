using BasedProject.DataAccess.IRepositories;
using BasedProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedProject.DataAccess.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly JustBlogContext _context;
        public TagRepository()
        {
            _context = _context;
        }
        public void AddTag(Tags Tag)
        {
            _context.Tags.Add(Tag);
            _context.SaveChanges();
        }

        public void DeleteTag(Tags Tag)
        {
            _context?.Tags.Remove(Tag);
            _context?.SaveChanges();
        }

        public void DeleteTag(int TagId)
        {
            var tag = _context.Tags.Find(TagId);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                _context.SaveChanges();
            }
        }

        public Tags Find(int TagId)
        {
            return _context.Tags.Find(TagId);
        }

        public IList<Tags> GetAllTags()
        {
            return _context.Tags.ToList();
        }

        public Tags GetTagByUrlSlug(string urlSlug)
        {
            return _context.Tags.FirstOrDefault(t => t.UrlSlug == urlSlug);
        }

        public void UpdateTag(Tags Tag)
        {
            var existingTag = _context.Tags.Find(Tag.Id);
            if(existingTag != null)
            {
                existingTag.Name = Tag.Name;
                existingTag.UrlSlug = Tag.UrlSlug;
                existingTag.Description = Tag.Description;
                existingTag.Count = Tag.Count;
            }
        }
    }
}
