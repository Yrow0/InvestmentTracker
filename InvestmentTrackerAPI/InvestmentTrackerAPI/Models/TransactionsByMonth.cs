using InvestmentTrackerAPI.Responses.Transactions;

namespace InvestmentTrackerAPI.Models
{
    public class TransactionsByMonth
    {
        public string Month { get; set; }
        public string Year { get; set; }
        public List<TransactionResponse> Transactions { get; set;}
    }
}
