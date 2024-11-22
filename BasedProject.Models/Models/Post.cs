using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedProject.Models.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title name is required.")]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string ShortDescription { get; set; }

        public string PostContent { get; set; }

        [StringLength(255)]
        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PostedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Modified { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }

        [NotMapped]
        public decimal Rate => RateCount == 0 ? 0 : (decimal)TotalRate / RateCount;

        public virtual Category Category { get; set; }

        public virtual ICollection<PostTagMap> PostTagMap { get; set; } = new List<PostTagMap>();

    }
}
