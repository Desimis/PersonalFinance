using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceApi.Interfaces
{
    public interface IMailService
    {
        Task<bool> SendMail(string from, string to, string subject, string body);
    }
}
