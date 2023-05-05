using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    public class UserRegistrationRequestDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
