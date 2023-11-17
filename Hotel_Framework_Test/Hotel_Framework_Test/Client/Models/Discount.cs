using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Framework_Test.Server.Models;

public partial class Discount
{
    [Key]
    public int DId { get; set; }

    public string? DName { get; set; }

    public string? DDescription { get; set; }

    public decimal? DRate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
