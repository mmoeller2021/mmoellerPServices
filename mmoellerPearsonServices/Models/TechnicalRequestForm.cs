using System.ComponentModel.DataAnnotations;

namespace mmoellerPearsonServices.Models
{
    public class TechnicalRequestForm
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Length(100,1000)]
        [Required]
        public string Description { get; set; }
        [Required]
        public DateOnly DueDate { get; set; }
    }
}
