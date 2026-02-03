using System;
using System.Diagnostics;

namespace Returns.Models;

[DebuggerDisplay("{ToString(),nq}")]
public sealed record InvestmentRes(
    Guid Id, //prefer Guids as easier for scaling + security
    Guid UserId,
    string Name,
    decimal ShareCount,
    decimal PurchaseCostPerShare,
    DateTime PurchaseDate)
{
    public override string ToString() => $"{Name} ({ShareCount} shares at {PurchaseCostPerShare:C} purchased on {PurchaseDate:d})";
}

