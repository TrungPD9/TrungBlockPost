using BasedProject.Models.Models;

namespace BasedProject.WebMVC.Models
{
    public class PostEditViewModel
    {
        public Post Post { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
