using PersonalFinanceApi.Models;
using PersonalFinanceApi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceApi.Interfaces
{
    public interface IExpenseService
    {
        BaseResponseDTO PostExpense(ExpenseModel expense);
        List<ExpenseDTO> GetExpensesForMonth(Guid userId, int month);
        ExpenseDTO GetExpense(Guid userId, Guid expenseId);
    }
}
