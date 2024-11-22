using BasedProject.DataAccess.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace BasedProject.WebMVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            var posts = _postRepository.GetAllPosts();
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
    }
}
