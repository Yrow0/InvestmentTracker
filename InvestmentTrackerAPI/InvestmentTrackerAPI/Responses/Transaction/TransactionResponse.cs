using InvestmentTrackerAPI.Models;
using InvestmentTrackerAPI.Responses.Category;
using InvestmentTrackerAPI.Responses.Type;

namespace InvestmentTrackerAPI.Responses.Transactions
{
    public class TransactionResponse
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public int CategoryId { get; set; }

        public string? Description { get; set; }

        public int TypeId { get; set; }

        public virtual CategoryResponse Category { get; set; } = null!;

        public virtual TransactionTypeResponse Type { get; set; } = null!;
    }
}
