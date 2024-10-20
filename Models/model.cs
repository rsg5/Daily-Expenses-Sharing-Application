namespace ExpenseSharingApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
    }

    public class ExpenseParticipant
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public decimal ExactAmount { get; set; }  // for exact split
        public decimal PercentageAmount { get; set; }  // for percentage split
    }

    public class Expense
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public List<ExpenseParticipant>? Participants { get; set; }
    }
}
