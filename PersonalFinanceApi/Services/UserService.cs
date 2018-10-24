using Microsoft.Extensions.Configuration;
using PersonalFinanceApi.Interfaces;
using PersonalFinanceApi.Models;
using PersonalFinanceApi.Models.Data;
using PersonalFinanceApi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceApi.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;

        public UserService(PersonalFinanceContext context,
            IConfiguration configuration,
            IMailService mailService) : base(context)
        {
            _configuration = configuration;
            _mailService = mailService;
        }
    }
}
