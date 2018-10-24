using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PersonalFinanceApi.Interfaces;
using PersonalFinanceApi.Models;
using PersonalFinanceApi.Models.Data;
using PersonalFinanceApi.Models.DTOs;
using PersonalFinanceApi.Models.Models;
using PersonalFinanceApi.Utilities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceApi.Services
{
    public class AuthService : ServiceBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;

        public AuthService(PersonalFinanceContext context,
            IConfiguration configuration,
            IMailService mailService) : base(context)
        {
            _configuration = configuration;
            _mailService = mailService;
        }

        public async Task<AuthResponseDTO> RegisterUser(RegisterModel model)
        {
            try
            {
                if (_context.Users.FirstOrDefault(x => x.Email == model.Email) != null)
                {
                    return new AuthResponseDTO { Result = false, ErrorMessage = "Email already in use" };
                }

                var from = "chrisgmills28@gmail.com";
                var subject = "Welcome to Personal Finance";
                var message = "Thank you for registering with Personal Finance, if you did not register, it appears someone has decided to use your email, too bad there's no confirmation yet :(";

                _context.Users.Add(new User
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Password = PasswordHelper.Encrypt(model.Password)
                });

                _context.SaveChanges();
                var mailSent = await _mailService.SendMail(from, model.Email, subject, message);
                return mailSent ? new AuthResponseDTO { Result = true } : new AuthResponseDTO { Result = false, ErrorMessage = "Fail to email user"};
            }
            catch (Exception e)
            {
                return new AuthResponseDTO { Result = false, ErrorMessage = "Failed to register user"};
            }
        }

        public async Task<AuthResponseDTO> Login(LoginModel model)
        {
            try
            {
                if (model.IsValid())
                {
                    var user = _context.Users.FirstOrDefault(x => x.Email == model.Email);
                    var result = PasswordHelper.Decrypt(user.Password);
                    if (result == model.Password)
                    {
                        return new AuthResponseDTO()
                        {
                            UserId = user.UserId,
                            Result = true,
                            AuthToken = GenerateJwtToken(user)
                        };
                    }
                    else
                    {
                        return new AuthResponseDTO()
                        {
                            Result = false,
                            ErrorMessage = "Invalid credentials",
                        };
                    }
                }
                else
                {
                    return new AuthResponseDTO()
                    {
                        Result = false,
                        ErrorMessage = "Invalid credentials",
                    };
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private string GenerateJwtToken(User user)
        {
            try
            {
                var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            };

                claims.Add(new Claim(ClaimTypes.Role, "USER"));

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

                var token = new JwtSecurityToken(
                    _configuration["JwtIssuer"],
                    _configuration["JwtIssuer"],
                    claims,
                    expires: expires,
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
