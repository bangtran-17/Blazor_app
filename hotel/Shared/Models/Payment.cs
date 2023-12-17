using System;
using System.Collections.Generic;

namespace Hotel.Shared.Models;

public partial class Payment
{
    public int PId { get; set; }

    public string? PStatus { get; set; }

    public string? PType { get; set; }

    public DateTime? PDatCoc { get; set; }

    public decimal? PAmout { get; set; }

    public int? BId { get; set; }

    public string? Status { get; set; }

    public virtual Booking? BIdNavigation { get; set; }
}
