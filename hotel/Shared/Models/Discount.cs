using System;
using System.Collections.Generic;

namespace Hotel.Shared.Models;

public partial class Discount
{
    public int DId { get; set; }

    public string? DName { get; set; }

    public string? DDescription { get; set; }

    public decimal? DRate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
