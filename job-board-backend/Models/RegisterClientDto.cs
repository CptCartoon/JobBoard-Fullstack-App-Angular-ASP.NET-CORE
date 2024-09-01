using JobBoardBackend.Entities;
using System.ComponentModel.DataAnnotations;

namespace JobBoardBackend.Models
{
    public class RegisterClientDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int RoleId { get; set; } = 3;
    }
}
