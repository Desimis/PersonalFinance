using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApi.Interfaces;
using PersonalFinanceApi.Models;
using PersonalFinanceApi.Models.DTOs;

namespace PersonalFinanceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(
            IExpenseService expenseService
            )
        {
            _expenseService = expenseService;
        }

        [HttpPost]
        public BaseResponseDTO PostExpense(ExpenseModel model)
        {
            try
            {
                return _expenseService.PostExpense(model);
            }
            catch (Exception e)
            {
                return new BaseResponseDTO(false, "Failed to log expense");
            }
        }

        [HttpGet]
        public ExpenseDTO GetExpense([FromQuery]Guid expenseId, [FromQuery]Guid userId)
        {
            try
            {
                return _expenseService.GetExpense(expenseId, userId);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        public List<ExpenseDTO> GetMonthlyExpenses([FromQuery]Guid userId, [FromQuery]int month)
        {
            try
            {
                return _expenseService.GetExpensesForMonth(userId, month);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}