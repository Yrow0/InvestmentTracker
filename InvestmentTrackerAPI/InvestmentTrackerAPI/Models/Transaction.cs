using System;
using System.Collections.Generic;

namespace InvestmentTrackerAPI.Models;

public class Transaction
{
    public Guid Id { get; set; }

    public DateTime Date { get; set; }

    public decimal Amount { get; set; }

    public int CategoryId { get; set; }

    public string? Description { get; set; }

    public int TypeId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Type Type { get; set; } = null!;
}
