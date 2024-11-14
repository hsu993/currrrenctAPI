using System;
using System.Collections.Generic;

namespace Currency.Model.Models;

public partial class Currency
{
    public int Id { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public string? CurrencyName { get; set; }

    public string? CurrencyLang { get; set; }

    public string? CurrencySymbol { get; set; }

    public decimal? CurrencyRate { get; set; }

    public string? CurrencyDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
