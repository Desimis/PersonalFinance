using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceApi.Models.Data
{
    public partial class Expense
    {
        [Key]
        public Guid ExpenseId { get; set; }

        public decimal Amount { get; set; }
        public Guid ExpenseDimensionId { get; set; }
        public Guid ExpenseCategoryId { get; set; }
        public Guid ExpenseTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Note { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("ExpenseDimensionId")]
        [InverseProperty("Expense")]
        public ExpenseDimension ExpenseDimension { get; set; }

        [ForeignKey("ExpenseTypeId")]
        [InverseProperty("Expense")]
        public ExpenseType ExpenseType { get; set; }

        [ForeignKey("ExpenseDimensionId")]
        [InverseProperty("Expense")]
        public ExpenseCategory ExpenseCategory { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Expenses")]
        public User User { get; set; }
    }
}
