using JobBoardBackend.Entities;
using System.ComponentModel.DataAnnotations;

namespace JobBoardBackend.Models
{
    public class RegisterCompanyDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int RoleId { get; set; } = 4;
    }
}
