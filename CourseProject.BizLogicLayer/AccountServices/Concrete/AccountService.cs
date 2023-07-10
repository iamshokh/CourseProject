using CourseProject.Core.Security;
using CourseProject.DataLayer.EfCode;
using CourseProject.DataLayer.Repositories;
using CourseProject.DataLayer.Repositories.Account;
using Microsoft.IdentityModel.Tokens;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BizLogicLayer.AccountServices
{
    public class AccountService : StatusGenericHandler, IAccountService
    {
        private readonly JwtSettings settings;
        private readonly IAccountRepository repository;
        private readonly EfCoreContext context;

        public AccountService(
            JwtSettings settings,
            IAccountRepository repository,
            EfCoreContext context)
        {
            this.settings = settings;
            this.repository = repository;
            this.context = context;
        }

        private async Task<string> AuthenticateAsync(
            string username,
            string password
            )
        {
            if (!IsValidUser(username, password))
            {
                AddError("Неправильное имя пользователя или пароль");
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var signingKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = settings.Issuer,
                Audience = settings.Audience,
                Expires = DateTime.UtcNow.AddMinutes(settings.ExpiresInMinutes),
                SigningCredentials = new SigningCredentials(signingKey,
                                                            SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin")
                })
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);

            //List<Claim> claims = new List<Claim>
            //{
            //    new Claim("sub", username),
            //    new Claim("role", "Admin")
            //};
            //JwtSecurityToken token2 = new JwtSecurityToken(settings.Issuer, settings.Issuer, claims, null, DateTime.UtcNow.AddMinutes(settings.ExpiresInMinutes), new SigningCredentials(signingKey,
            //                                                SecurityAlgorithms.HmacSha256));

            return tokenHandler.WriteToken(token);
        }

        private bool IsValidUser(string userName,
                                 string password)
        {
            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var user = repository.ByUserName(userName);

            if (user == null || !user.IsValidPassword(password))
            {
                return false;
            }

            return true;
        }

        public async Task<string> Login(LoginDto dto)
        {
            try
            {
                string result = await AuthenticateAsync(dto.UserName, dto.Password);
                if (!IsValid)
                {
                    AddError("Ошибка при Аутентификации");
                    return null;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> Registrate(RegistrateUserDlDto dto)
        {
            try
            {
                var user = repository.Registrate(dto);
                if (!IsValid)
                {
                    AddError("Ошибка при Регистрации");
                    return null;
                }
                context.Add(user);
                context.SaveChanges();
                string result = await AuthenticateAsync(dto.UserName, dto.Password);
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
