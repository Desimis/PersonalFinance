using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceApi.Models.DTOs
{
    public class BaseResponseDTO
    {
        public BaseResponseDTO()
        {
        }

        public BaseResponseDTO(bool result, string errorMessage = "")
        {
            Result = result;
            ErrorMessage = errorMessage;
        }

        public BaseResponseDTO(bool result, Guid id)
        {
            Result = result;
            Id = id;
        }

        public bool Result { get; set; }
        public Guid? Id { get; set; }
        public string ErrorMessage { get; set; }
    }
}
