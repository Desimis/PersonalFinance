using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceApi.Models
{
    public class ExpenseModel
    {
        public Guid ExpenseId { get; set; }
        public decimal Amount { get; set; }
        public Guid ExpenseDimensionId { get; set; }
        public Guid ExpenseCategoryId { get; set; }
        public Guid ExpenseTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Note { get; set; }
        public Guid UserId { get; set; }

        public bool IsValid()
        {
            return ExpenseDimensionId != Guid.Empty &&
                UserId != Guid.Empty &&
                ExpenseCategoryId != Guid.Empty &&
                ExpenseTypeId != Guid.Empty &&
                Amount != decimal.Zero;
        }
    }
}
