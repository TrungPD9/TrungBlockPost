using BasedProject.DataAccess.IRepositories;
using BasedProject.DataAccess.Repositories;
using BasedProject.Models.Models;
using BasedProject.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BasedProject.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ILogger<HomeController> logger, IPostRepository postRepository , ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var post = _postRepository.GetAllPosts().OrderByDescending(p => p.PostedOn).Take(5).ToList();
            var categories = _categoryRepository.GetAllCategories();

            // Truyền danh sách categories vào ViewBag
            ViewBag.Categories = categories;
            return View(post);
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
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult About()
        {
            return View();

        }
        public IActionResult SamplePost()
        {

            return View();
        }
        public IActionResult Contact()
        {
          

            return View();
        }
        public IActionResult PostsByCategory(int id)
        {
            // Lấy tên category từ id
            var category = _categoryRepository.Find(id);
            if (category == null)
            {
                return NotFound(); // Nếu category không tồn tại, trả về NotFound
            }

            // Truy vấn các bài viết theo tên category
            var posts = _postRepository.GetPostsByCategory(category.Name);
            if (!posts.Any())
            {
                return NotFound();
            }
            var categories = _categoryRepository.GetAllCategories();

            // Truyền danh sách categories vào ViewBag
            ViewBag.Categories = categories;
            return View("Index", posts); // Trả về danh sách bài viết
        }
    }
}
