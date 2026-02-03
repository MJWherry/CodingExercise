using System;

namespace Returns.Models;

public class InvestmentQuery
{
    public Guid? UserId { get; set;}

    public int? Start { get; set; } = 0;

    public int Amount { get; set; } = 0;
}