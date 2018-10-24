using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceApi.Models.DTOs
{
    public class ExpenseDTO
    {
        public Guid ExpenseId { get; set; }
        public decimal Amount { get; set; }
        public string ExpenseDimensionName { get; set; }
        public string ExpenseCategoryName { get; set; }
        public string ExpenseTypeName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Note { get; set; }
        public Guid UserId { get; set; }
    }
}
