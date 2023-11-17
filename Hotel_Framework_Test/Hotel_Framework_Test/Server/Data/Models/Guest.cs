using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Framework_Test.Server.Models;

public partial class Guest
{
    [Key]
    public int GId { get; set; }

    public string? GFirstName { get; set; }

    public string? GLastName { get; set; }

    public string? GSdt { get; set; }

    public string? GEmail { get; set; }

    public string? GCccd { get; set; }

    public string? GAccount { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}
