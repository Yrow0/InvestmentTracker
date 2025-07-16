using System;
using System.Collections.Generic;

namespace InvestmentTrackerAPI.Models;

public class TransactionType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
