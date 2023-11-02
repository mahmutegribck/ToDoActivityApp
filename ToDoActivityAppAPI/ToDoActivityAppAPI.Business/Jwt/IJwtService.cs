using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.Jwt.DTOs;
using ToDoActivityAppAPI.Entity.Identity;

namespace ToDoActivityAppAPI.Business.Jwt
{
    public interface IJwtService
    {
        Task<JwtTokenDTO> CreateJwtToken(ApplicationUser user);
    }
}
