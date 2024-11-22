using BasedProject.DataAccess.Repositories;
using BasedProject.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BasedProject.UnitTest
{
    public class Tests
    {
        [TestFixture]
        public class CategoryRepositoryUnitTest
        {
            private JustBlogContext _context;
            private CategoryRepository _repository;

            [SetUp]
            public void Setup()
            {
                _context = new JustBlogContext();
                _repository = new CategoryRepository(_context);

                // Xóa dữ liệu cũ và seed lại dữ liệu nếu cần
                _context.Categories.RemoveRange(_context.Categories);
                _context.SaveChanges();

                _context.Categories.Add(new Category
                {
                    
                    Name = "Test Category",
                    UrlSlug = "test-category",
                    Description = "Test category description"
                });
                _context.SaveChanges();
            }

            [TearDown]
            public void Cleanup()
            {
                _context.Dispose();
            }

            [Test]
            public void AddCategory_NormalCase_Success()
            {
                // Arrange
                var category = new Category
                {
                    
                    Name = "New Category",
                    UrlSlug = "new-category",
                    Description = "New category description"
                };

                // Act
                _repository.AddCategory(category);

                // Assert
                var addedCategory = _repository.GetAllCategories()
                                               .FirstOrDefault(c => c.Name == "New Category");
                Assert.IsNotNull(addedCategory);
                Assert.AreEqual("new-category", addedCategory.UrlSlug);
            }

            [Test]
            public void AddCategory_InvalidField_ShouldFail()
            {
                // Arrange
                var category = new Category
                {

                    
                    Name = "", // Tên không hợp lệ
                    UrlSlug = "new-category",
                    Description = "New category description"
                };

                // Act & Assert
                Assert.Throws<Exception>(() => _repository.AddCategory(category));
            }
        }
    }
}