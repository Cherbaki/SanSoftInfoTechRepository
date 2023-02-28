using System.ComponentModel.DataAnnotations;

namespace SanSoftInfoTech.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public required string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Password { get; set; }

    }
}
