using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceApi.Models.Data
{
    public class ExpenseType
    {
        public Guid ExpenseTypeId { get; set; }
        public string Name { get; set; }
        public Guid ExpenseCategoryId { get; set; }

        [InverseProperty("ExpenseType")]
        public Expense Expense { get; set; }

        [ForeignKey("ExpenseCategoryId")]
        [InverseProperty("ExpenseTypes")]
        public ExpenseCategory ExpenseCategory { get; set; }
    }
}
