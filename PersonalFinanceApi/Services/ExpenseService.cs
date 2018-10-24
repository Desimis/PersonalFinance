using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using PersonalFinanceApi.Models;
using PersonalFinanceApi.Interfaces;
using PersonalFinanceApi.Models.Data;
using PersonalFinanceApi.Models.DTOs;

namespace PersonalFinanceApi.Services
{
    public class ExpenseService : ServiceBase, IExpenseService
    {
        private readonly IConfiguration _configuration;

        public ExpenseService(PersonalFinanceContext context,
            IConfiguration configuration) : base(context)
        {
            _configuration = configuration;
        }

        public BaseResponseDTO PostExpense(ExpenseModel expense)
        {
            try
            {
                if (expense.IsValid())
                {
                    if (_context.Users.FirstOrDefault(x => x.UserId == expense.UserId) == null)
                    {
                        return new BaseResponseDTO(false, "User does not exist");
                    }

                    var addExpense = _context.Expenses.Add(new Expense
                    {
                        ExpenseDimensionId = expense.ExpenseDimensionId,
                        ExpenseCategoryId = expense.ExpenseCategoryId,
                        ExpenseTypeId = expense.ExpenseTypeId,
                        UserId = expense.UserId,
                        Note = !string.IsNullOrEmpty(expense.Note) ? expense.Note : null,
                        Amount = expense.Amount,
                        DateCreated = DateTime.UtcNow
                    });

                    _context.SaveChanges();
                    return new BaseResponseDTO(true);
                }
                else
                {
                    return new BaseResponseDTO(false, "Form fields are invalid.");
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<ExpenseDTO> GetExpensesForMonth(Guid userId, int month)
        {
            try
            {
                if (_context.Users.FirstOrDefault(x => x.UserId == userId) == null)
                {
                    return null;
                }

                var expenses = new List<ExpenseDTO>();
                var monthlyExpenses = _context.Expenses.Where(x => x.UserId == userId && x.DateCreated.Month == month).ToList();

                if (monthlyExpenses.Count > 0)
                {
                    foreach (var expense in monthlyExpenses)
                    {
                        expenses.Add(new ExpenseDTO
                        {
                            ExpenseId = expense.ExpenseId,
                            Amount = expense.Amount,
                            ExpenseCategoryName = expense.ExpenseCategory.Name,
                            ExpenseDimensionName = expense.ExpenseDimension.Name,
                            ExpenseTypeName = expense.ExpenseType.Name,
                            Note = expense.Note,
                            DateCreated = expense.DateCreated
                        });
                    }

                    return expenses;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ExpenseDTO GetExpense(Guid userId, Guid expenseId)
        {
            try
            {
                if (_context.Users.FirstOrDefault(x => x.UserId == userId) == null)
                {
                    return null;
                }

                var expense = _context.Expenses.FirstOrDefault(x => x.UserId == userId && x.ExpenseId == expenseId);

                if (expense != null)
                {
                    return new ExpenseDTO
                    {
                        ExpenseId = expense.ExpenseId,
                        Amount = expense.Amount,
                        ExpenseCategoryName = expense.ExpenseCategory.Name,
                        ExpenseDimensionName = expense.ExpenseDimension.Name,
                        ExpenseTypeName = expense.ExpenseType.Name,
                        Note = expense.Note,
                        DateCreated = expense.DateCreated
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
