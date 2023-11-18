using System;
using System.Collections.Generic;

namespace Hotel.Shared.Models;

public partial class Roomtype
{
    public int RtId { get; set; }

    public string? RtDes { get; set; }

    public string? RtName { get; set; }

    public decimal? RtCost { get; set; }

    public string? RtSmokeFriendly { get; set; }

    public string? Status { get; set; }

    public decimal? RArea { get; set; }

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
