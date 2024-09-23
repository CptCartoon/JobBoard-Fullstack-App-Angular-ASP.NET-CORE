using JobBoardBackend.Entities;
using System.ComponentModel.DataAnnotations;

namespace JobBoardBackend.Models
{
    public class RegisterCompanyDto
    {

        public string Email { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int RoleId { get; set; } = 4;
    }
}
