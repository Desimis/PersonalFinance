using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceApi.Models
{
    public class ExpenseCategoryModel
    {
        public Guid ExpenseCategoryId { get; set; }
        public string Name { get; set; }
    }
}
