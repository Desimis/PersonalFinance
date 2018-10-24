using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceApi.Models.Data
{
    public partial class ExpenseDimension
    {
        [Key]
        public Guid ExpenseDimensionId { get; set; }
        public string Name { get; set; }

        [InverseProperty("ExpenseDimension")]
        public Expense Expense { get; set; }
    }
}
