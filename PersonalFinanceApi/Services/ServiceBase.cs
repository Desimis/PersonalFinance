using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinanceApi.Models;

namespace PersonalFinanceApi.Services
{
    public class ServiceBase
    {
        protected readonly PersonalFinanceContext _context;

        public ServiceBase(PersonalFinanceContext context)
        {
            _context = context;
        }
    }
}
