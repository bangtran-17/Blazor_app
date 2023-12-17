using System;
using System.Collections.Generic;
using Hotel.Shared.Models;

namespace Hotel.Shared.Models;

public partial class Room
{
    public int RId { get; set; }

    public string? RNumber { get; set; }

    public int? RtId { get; set; }

    public string? RAvailable { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Roomtype? Rt { get; set; }
}
