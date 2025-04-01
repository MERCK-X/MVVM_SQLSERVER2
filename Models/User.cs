using System.ComponentModel.DataAnnotations;

namespace MVVM_SQLSERVER2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}