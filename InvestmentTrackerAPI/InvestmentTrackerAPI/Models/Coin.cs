using System;
using System.Collections.Generic;

namespace InvestmentTrackerAPI.Models;

public class Coin
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string CoinId { get; set; } = null!;
}
