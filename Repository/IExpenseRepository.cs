using ExpenseSharingApp.Models;

namespace ExpenseSharingApp.Repositories
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetExpensesByUserIdAsync(int userId);
        Task AddExpenseAsync(Expense expense);
        Task<Expense?> GetExpenseByIdAsync(int id);
    }
}
