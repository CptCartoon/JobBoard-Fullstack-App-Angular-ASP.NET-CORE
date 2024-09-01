using JobBoardBackend.Entities;
using JobBoardBackend.Models;

namespace JobBoardBackend.Services
{ 
    public interface IAccountService
    {
        void RegisterClient(RegisterClientDto dto);
        void RegisterCompany(RegisterCompanyDto dto);
    }
    public class AccountService : IAccountService
    {
        private readonly AuthorizationDbContext _context;
        public AccountService(AuthorizationDbContext context) {
            _context = context;
        }
        public void RegisterClient(RegisterClientDto dto)
        {
            var newUser = new UserLogin()

            {
                Email = dto.Email,
                PasswordHash = dto.Password,
                RoleId = dto.RoleId,
            };

           _context.UserLogin.Add(newUser);
           _context.SaveChanges(); 

            var newClient = new Client()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                City = dto.City,
                Country = dto.Country,
                UserLoginId = newUser.Id,
            };

            _context.Clients.Add(newClient);
            _context.SaveChanges();
        }

        public void RegisterCompany(RegisterCompanyDto dto)
        {
            var newUser = new UserLogin()

            {
                Email = dto.Email,
                PasswordHash = dto.Password,
                RoleId = dto.RoleId,
            };

            _context.UserLogin.Add(newUser);
            _context.SaveChanges();

            var newCompany = new Company()
            {
                Name = dto.Name,
                Description = dto.Description,  
                Country = dto.Country,  
                City = dto.City,
                UserLoginId = newUser.Id,
            };

            _context.Companies.Add(newCompany);
            _context.SaveChanges();
        }
    }
}