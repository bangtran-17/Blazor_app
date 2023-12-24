using System;
using System.Collections.Generic;

namespace Hotel.Shared.Models;

public partial class Feedback
{
    public int FId { get; set; }

    public string? FDescription { get; set; }

    public DateTime? FDate { get; set; }

    public int? FRate { get; set; }

    public int? GId { get; set; }

    public int? BId { get; set; }

    public string? Status { get; set; }

    public virtual Booking? BIdNavigation { get; set; }

    public virtual Guest? GIdNavigation { get; set; }
}
