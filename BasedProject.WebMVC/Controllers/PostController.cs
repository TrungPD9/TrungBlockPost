using BasedProject.DataAccess.IRepositories;
using BasedProject.DataAccess.Repositories;
using BasedProject.Models.Models;
using BasedProject.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasedProject.WebMVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        public PostController(IPostRepository postRepository , ICategoryRepository categoryRepository )
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            
        }

        public IActionResult Index()
        {
            var posts = _postRepository.GetAllPosts().ToList();
            //var categories = _categoryRepository.GetAllCategories();
            //if (categories == null || !categories.Any())
            //{
            //    categories = new List<Category>();
            //}
            //ViewBag.Categories = categories;

            return View(posts);
        }

        public IActionResult Details(int id)
        {
            var post = _postRepository.FindPost(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        public ActionResult LatestPost()
        {
            // Lấy danh sách bài viết mới nhất từ repository
            var latestPosts = _postRepository.GetAllPosts()
                                             .OrderByDescending(post => post.PostedOn)
                                             .Take(5) // Số lượng bài viết cần hiển thị (tùy chỉnh)
                                             .ToList();

            return View(latestPosts);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _postRepository.FindPost(id);
            if (post == null)
            {
                return NotFound();
            }

            var categories = _categoryRepository.GetAllCategories();
            var viewModel = new PostEditViewModel
            {
                Post = post,
                Categories = categories
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                _postRepository.UpdatePost(post); // Cập nhật bài viết
                return RedirectToAction("Index"); // Chuyển hướng về danh sách bài viết
            }

            ViewBag.Categories = _categoryRepository.GetAllCategories(); // Nếu có lỗi, trả lại danh mục
            return View(post);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var post = _postRepository.FindPost(id); // Tìm bài viết theo ID
            if (post == null)
            {
                return NotFound(); // Nếu bài viết không tồn tại, trả về lỗi 404
            }

            return View(post); // Trả về View xác nhận xóa bài viết
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _postRepository.DeletePost(id); // Gọi repository để xóa bài viết
            return RedirectToAction("Index"); // Chuyển hướng về danh sách bài viết
        }
       

    }
}
