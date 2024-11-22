using BasedProject.DataAccess.IRepositories;
using BasedProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedProject.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly JustBlogContext _context;
        public CategoryRepository(JustBlogContext context)
        {
            _context = _context;
        }
        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            _context?.Categories.Remove(category);
            _context?.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);  
                _context.SaveChanges();
            }
                
        }

        public Category Find(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }

        public IList<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public void UpdateCategory(Category category)
        {
            var existingCategory = _context.Categories.Find(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.UrlSlug = category.UrlSlug;
                existingCategory.Description = category.Description;
                _context.Categories.Update(existingCategory);
                _context.SaveChanges();
            }
        }
    }
}
