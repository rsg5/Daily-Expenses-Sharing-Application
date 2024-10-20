using Microsoft.EntityFrameworkCore;

namespace ExpenseSharingApp.Models
{
    public class ExpenseSharingContext : DbContext
    {
        public ExpenseSharingContext(DbContextOptions<ExpenseSharingContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseParticipant> ExpenseParticipants { get; set; }
    }
}

