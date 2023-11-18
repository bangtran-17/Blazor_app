using System;
using System.Collections.Generic;

namespace Hotel.Shared.Models;

public partial class Room
{
    public int RId { get; set; }

    public string? RNumber { get; set; }

    public int? RtId { get; set; }

    public string? RAvailable { get; set; }

    public string? Status { get; set; }

    public virtual Roomtype? Rt { get; set; }

    public virtual ICollection<Booking> BIds { get; } = new List<Booking>();
}
