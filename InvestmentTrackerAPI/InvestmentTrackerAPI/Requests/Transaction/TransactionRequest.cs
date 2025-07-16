using System.ComponentModel.DataAnnotations;

namespace InvestmentTrackerAPI.Requests.Transactions
{
    public class TransactionRequest
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public decimal Amount { get; set; }

        public int CategoryId { get; set; }

        public string? Description { get; set; }

        public int TypeId { get; set; }

    }
}
