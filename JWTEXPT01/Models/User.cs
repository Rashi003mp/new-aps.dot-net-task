using System.ComponentModel.DataAnnotations;

namespace JwtApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; } // plain for demo, hash in production

        [Required]
        public string Role { get; set; } // "Admin" or "User"
    }
}
