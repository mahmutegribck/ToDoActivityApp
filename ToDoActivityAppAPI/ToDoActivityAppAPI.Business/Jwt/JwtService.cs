using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.Jwt.DTOs;
using ToDoActivityAppAPI.Entity.Identity;

namespace ToDoActivityAppAPI.Business.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public JwtService(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<JwtTokenDTO> CreateJwtToken(ApplicationUser user)
        {
            JwtTokenDTO jwtTokenDTO = new JwtTokenDTO();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"] ?? string.Empty));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                

            }.Union(roleClaims);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
          (
              audience: _configuration["Jwt:Audience"],
              issuer: _configuration["Jwt:Issuer"],
              claims: claims,
              
              signingCredentials: signingCredentials
          );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            jwtTokenDTO.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenDTO;
        }
    }
}
