using Microsoft.EntityFrameworkCore;
using ExpenseSharingApp.Models;

namespace ExpenseSharingApp.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseSharingContext _context;

        public ExpenseRepository(ExpenseSharingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expense>> GetExpensesByUserIdAsync(int userId)
        {
            return await _context.Expenses
                .Where(e => e.Participants.Any(p => p.User.Id == userId))
                .ToListAsync();
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<Expense?> GetExpenseByIdAsync(int id)
        {
            return await _context.Expenses.FindAsync(id);
        }
    }
}
