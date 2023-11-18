using System;
using System.Collections.Generic;

namespace Hotel.Shared.Models;

public partial class Servicesbooked
{
    public int SId { get; set; }

    public int BId { get; set; }

    public string? Status { get; set; }

    public virtual Booking BIdNavigation { get; set; } = null!;

    public virtual Service SIdNavigation { get; set; } = null!;
}
