using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceApi.Models.Data
{
    public class ExpenseCategory
    {
        public Guid ExpenseCategoryId { get; set; }
        public string Name { get; set; }

        [InverseProperty("ExpenseCategory")]
        public ICollection<ExpenseType> ExpenseTypes { get; set; }
    }
}
