using JobBoardBackend.Entities;
using JobBoardBackend.Entities.AuthEntities;
using JobBoardBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobBoardBackend.Services
{
    public interface IAccountService
    {
        void RegisterClient(RegisterClientDto dto);
        void RegisterCompany(RegisterCompanyDto dto);
        string GenerateJwt(LoginDto dto);
    }
    public class AccountService : IAccountService
    {
        private readonly JobBoardDbContext _context;
        private readonly IPasswordHasher<UserLogin> _passwordHasher;
        private readonly AuthenticationSettings _authSettings;
        public AccountService(JobBoardDbContext context, IPasswordHasher<UserLogin> passwordHasher, AuthenticationSettings authSettings) {
            _context = context;
            _passwordHasher = passwordHasher;
            _authSettings = authSettings;
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

            var hashedPaswsword = _passwordHasher.HashPassword(newUser, dto.Password);

            newUser.PasswordHash = hashedPaswsword;

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

        public string GenerateJwt(LoginDto dto)
        {
            var user = _context.UserLogin
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == dto.Email);

            if(user is null)
            {
                throw new Exception("Email or password is incorrect");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if(result == PasswordVerificationResult.Failed)
            {
                throw new Exception("Email or password is incorrect");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                // new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authSettings.JwtIssuer, _authSettings.JwtIssuer, claims, expires: expires, signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}