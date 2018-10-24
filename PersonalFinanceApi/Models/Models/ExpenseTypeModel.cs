using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceApi.Models
{
    public class ExpenseTypeModel
    {
        public Guid ExpenseTypeId { get; set; }
        public string Name { get; set; }
        public Guid ExpenseCategoryId { get; set; }
    }
}
