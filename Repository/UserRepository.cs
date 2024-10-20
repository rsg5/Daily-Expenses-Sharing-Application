using Microsoft.EntityFrameworkCore;
using ExpenseSharingApp.Models;


namespace ExpenseSharingApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpenseSharingContext _context;

        public UserRepository(ExpenseSharingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }


        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user ?? null; // Return null if not found
        }


        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
