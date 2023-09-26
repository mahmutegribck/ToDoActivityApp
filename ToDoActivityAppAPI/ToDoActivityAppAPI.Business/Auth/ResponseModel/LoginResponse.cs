using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoActivityAppAPI.Business.Jwt.DTOs;

namespace ToDoActivityAppAPI.Business.Auth.ResponseModel
{
    public class LoginResponse
    {
        public JwtTokenDTO JwtTokenDTO { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

    }
}
