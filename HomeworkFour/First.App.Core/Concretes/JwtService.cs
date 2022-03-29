using First.App.Business.Abstract;
using First.App.Business.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace First.App.Business.Concretes
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration configuration;
        private readonly IUserService userService;
        public JwtService(IConfiguration configuration, IUserService userService)
        {
            this.configuration=configuration;
            this.userService=userService;
        }

        /// <summary>
        /// Users Repositoryi yazıp bu dataları veritabanından da çekebilirsiniz.
        /// </summary>
        //Dictionary<string, string> users = new Dictionary<string, string>
        //{
        //    { "user1","password1"},
        //    { "user2","password2"},
        //    { "user3","password3"},
        //}; 

        public TokenDto Authenticate(UserDto user)
        {
            var users = userService.GetAllUser();
            if (!users.Any(x => x.Username == user.Name && x.Password == user.Password))
            {
                return null;
            }

            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, user.Name)
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenDto 
            { 
                Token = tokenHandler.WriteToken(token) 
            };
        }
    }
}
