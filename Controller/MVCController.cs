using Microsoft.AspNetCore.Mvc;
using ExpenseSharingApp.Models;
using ExpenseSharingApp.Repositories;
using System.Text;

namespace ExpenseSharingApp.Controllers
{
    [ApiController]
    [Route("api/expenses")]
    public class MVCController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;

        public MVCController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(Expense expense)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (expense.Participants.Sum(p => p.PercentageAmount) != 100)
                {
                    return BadRequest("Total percentage split must equal 100%.");
                }

                await _expenseRepository.AddExpenseAsync(expense);
                return Ok(expense);
            }
            catch (Exception ex)
            {
                // Log the exception
                // _logger.LogError(ex, "Error occurred while adding an expense.");
                return StatusCode(500, new { Message = "An error occurred while adding the expense." });
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserExpenses(int userId)
        {
            var expenses = await _expenseRepository.GetExpensesByUserIdAsync(userId);
            return Ok(expenses);
        }

        [HttpGet("balancesheet/{userId}")]
        public async Task<IActionResult> DownloadBalanceSheet(int userId)
        {
            var expenses = await _expenseRepository.GetExpensesByUserIdAsync(userId);

            var csv = new StringBuilder();
            csv.AppendLine("Expense Description,Amount,User");
            foreach (var expense in expenses)
            {
                foreach (var participant in expense.Participants)
                {
                    csv.AppendLine($"{expense.Description},{participant.ExactAmount},{participant.User.Name}");
                }
            }

            return File(Encoding.UTF8.GetBytes(csv.ToString()), "text/csv", "BalanceSheet.csv");
        }
    }
}
