using System.ComponentModel.DataAnnotations;

namespace resqdoc.Models
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}