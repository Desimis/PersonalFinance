using Microsoft.EntityFrameworkCore;
using PersonalFinanceApi.Models.Data;

namespace PersonalFinanceApi.Models
{
    public class PersonalFinanceContext : DbContext
    {
        public PersonalFinanceContext(DbContextOptions<PersonalFinanceContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<ExpenseDimension> ExpenseDimensions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
