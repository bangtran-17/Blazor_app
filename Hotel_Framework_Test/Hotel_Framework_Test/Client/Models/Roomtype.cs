using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Framework_Test.Server.Models;

public partial class Roomtype
{
    [Key]
    public int RtId { get; set; }

    public string? RtDes { get; set; }

    public string? RtName { get; set; }

    public decimal? RtCost { get; set; }

    public string? RtSmokeFriendly { get; set; }

    public string? Status { get; set; }

    public decimal? RArea { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
