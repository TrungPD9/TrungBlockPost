using BasedProject.DataAccess.IRepositories;
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

        public HomeController(ILogger<HomeController> logger, IPostRepository postRepository)
        {
            _logger = logger;
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            // Lấy danh sách Category từ cơ sở dữ liệu
/*            var categories = _postRepository.GetAllPosts()
                .Select(c => new { c.Name, c.UrlSlug })
                .ToList();*/

            // Truyền danh sách Category vào ViewBag
           /* ViewBag.Categories = categories;*/
            var post = _postRepository.GetAllPosts();
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
    }
}
