using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceApi.Models.DTOs
{
    public class AuthResponseDTO : BaseResponseDTO
    {
        public string AuthToken { get; set; }
        public bool OutstandingOtp { get; set; }
        public Guid? UserId { get; set; }
        public string Email { get; set; }
    }
}
