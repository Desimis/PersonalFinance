using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceApi.Models.Data
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Income { get; set; }
        public int SavePercentage { get; set; }
        public string Password { get; set; }

        [InverseProperty("User")]
        public ICollection<Expense> Expenses { get; set; }
    }
}
