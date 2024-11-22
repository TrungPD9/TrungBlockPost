using System.ComponentModel.DataAnnotations;

namespace BasedProject.Models.BaseEntities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
