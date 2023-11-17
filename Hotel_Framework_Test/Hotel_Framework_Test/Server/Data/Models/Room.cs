using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Framework_Test.Server.Models;

public partial class Room
{
    [Key]
    public int RId { get; set; }

    public string? RNumber { get; set; }

    public int? RtId { get; set; }

    public string? RAvailable { get; set; }

    public string? Status { get; set; }

    public virtual Roomtype? Rt { get; set; }

    public virtual ICollection<Booking> BIds { get; set; } = new List<Booking>();
}
