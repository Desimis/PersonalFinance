using PersonalFinanceApi.Models.Data;
using PersonalFinanceApi.Models.DTOs;
using PersonalFinanceApi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceApi.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> Login(LoginModel model);
        Task<AuthResponseDTO> Register(RegisterModel model);
        bool Logout(string token);
        AuthResponseDTO ConfirmOTP(User user, string code);
    }
}
