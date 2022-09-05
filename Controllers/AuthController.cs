using Microsoft.AspNetCore.Mvc;
using Diplom.Models;
using Diplom.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using Diplom.Auth.Common;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Diplom.Auth.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IOptions<AuthOptions> authOptions;
        private readonly ApplicationContext Context;

        public AuthController(IOptions<AuthOptions> authOptions, ApplicationContext context)
        {
            this.authOptions = authOptions;
            Context = context;
        }



        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] Login loginRequest)
        {
            var user = AuthenticatieUser(loginRequest.Email, loginRequest.Password);

            if (user != null)
            {
                var token = GenerateJWT(user);
                Context.Accounts.FirstOrDefault(x => x.Email == loginRequest.Email).InSystem = true;
                Context.SaveChanges();
                return Ok(new { accessToken = token, refreshToken = token, user = new { email = user.Email, isActivated = true, id = user.Id } });
            }

            return Unauthorized();
        }

        private Account AuthenticatieUser(string email, string password)
        {
            return Context.Accounts.SingleOrDefault<Account>(x => x.Email == email && x.Password == HashPassword(password));
        }

        private string GenerateJWT (Account user)
        {
            var authParams = authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            claims.Add(new Claim("role", user.AccountRole.ToString()));

            var token = new JwtSecurityToken(authParams.Issure,
                authParams.Audiecne,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private string UserId => User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;




        [Route("registration")]
        [HttpPost]
        public IActionResult Registration([FromBody] RegistrationUser registrationUser )
        {
            Context.Accounts.Add(new Account() { UserRole = new UserRole() { UserRoleStr = registrationUser.AccountRole },
                Email = registrationUser.Email,
                Password = HashPassword(registrationUser.Password),
                FirstName = registrationUser.FirstName, 
                LastName = registrationUser.LastName,
                Patronymic = registrationUser.Patronymic,
                PhoneNumber = registrationUser.phoneNumber,
                NickName = registrationUser.Nickname
            });
            Context.SaveChanges();

            var user = AuthenticatieUser(registrationUser.Email, registrationUser.Password);

            if (user != null)
            {
                var token = GenerateJWT(user);

                return Ok(new { accessToken = token, refreshToken = token, user = new { email = user.Email, isActivated = true, id = user.Id } });
            }

            return BadRequest();
        }

        [Route("check")]
        [Authorize]
        [HttpPost]
        public IActionResult Check()
        {
            return Ok();
        }

        [Route("logout")]
        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Logout()
        {
            Context.Accounts.FirstOrDefault(x => x.Id == int.Parse(UserId)).InSystem = true;
            Context.SaveChanges();
            return Ok();
        }

        public static string HashPassword (string password )
        {
            var md5 = MD5.Create();

            byte[] passwordAscii = Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(passwordAscii);


            var STR = new StringBuilder();
            foreach (var x in hash)
                STR.Append(x.ToString("X2"));
            return STR.ToString();
        }
    }

    public class AuthentificatorUser
    {
        private readonly ApplicationContext Context;

        public AuthentificatorUser(ApplicationContext context)
        {
            Context = context;
        }

        public Account AuthenticatieUser(string email, string password)
        {
            return Context.Accounts.Include(x => x.ChatRooms).SingleOrDefault<Account>(x => x.Email == email && x.Password == HashPassword(password));
        }

        public static string HashPassword(string password)
        {
            var md5 = MD5.Create();

            byte[] passwordAscii = Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(passwordAscii);


            var STR = new StringBuilder();
            foreach (var x in hash)
                STR.Append(x.ToString("X2"));
            return STR.ToString();
        }
    }
}
