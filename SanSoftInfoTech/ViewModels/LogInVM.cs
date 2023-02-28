using System.ComponentModel.DataAnnotations;

namespace SanSoftInfoTech.ViewModels
{
    public class LogInVM
    {
        [Required]
        [MaxLength(50)]
        public required string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Password { get; set; }
    }
}
