using AutoMapper;
using AvukatProjectCore.DTOs;
using AvukatProjectCore.Model;
using AvukatProjectCore.Services;
using AvukatProjectRepository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AvukatProject.API.Controllers
{
    public class AuthController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Users> _service;

        private readonly AppDbContext _context;

        public AuthController(IMapper mapper, IService<Users> service, AppDbContext context)
        {
            _context = context;
            _service = service;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto model)
        {
            // Kullanıcı giriş bilgilerini doğrula ve token oluştur
            var dataUser = _context.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            var dataLawyer = _context.Lawyers.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (dataUser != null)
            {
                var role = "users";
                var (token, expiration) = GenerateToken(role);

                var response = new
                {
                    Email = dataUser.Email,
                    Id=dataUser.Id,
                    Password = dataUser.Password,
                    Role = role,
                    Token = token,
                    expirationTime = expiration,
                    AuthorizedUser = dataUser
                };

                return Ok(response);
            }
            else if (dataLawyer != null)
            {
                var role = "lawyers";
                var (token, expiration) = GenerateToken(role);

                var response = new
                {
                    Email= dataLawyer.Email,
                    Password= dataLawyer.Password,
                    Role = role,
                    Token = token,
                    expirationTime = expiration,
                    AuthorizedUser = dataLawyer 
                };

                return Ok(response);
            }

            return Unauthorized();
        }

        private (string Token, DateTime Expires) GenerateToken(string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretKey1234567890"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expirationTime = DateTime.Now.AddDays(1); // Geçerlilik süresi 1 gün

            var token = new JwtSecurityToken(
                issuer: "YourIssuer",
                audience: "YourAudience",
                claims: claims,
                expires: expirationTime,
                signingCredentials: creds
            );

            return (new JwtSecurityTokenHandler().WriteToken(token), expirationTime);
        }
    }
}
