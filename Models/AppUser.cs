

using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public ICollection<Order>? Orders { get; set; } = new List<Order>();
    }
}