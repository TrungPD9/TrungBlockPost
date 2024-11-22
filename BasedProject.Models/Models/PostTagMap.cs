using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedProject.Models.Models
{
    public class PostTagMap
    {
        [ForeignKey("Post")]
        public int PostId { get; set; }

        [ForeignKey("Tags")]
        public int TagId { get; set; }

        public virtual Post Post { get; set; }

        public virtual Tags Tags { get; set; }
    }
}
