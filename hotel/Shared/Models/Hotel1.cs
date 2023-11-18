using System;
using System.Collections.Generic;

namespace Hotel.Shared.Models;

public partial class Hotel1
{
    public int HId { get; set; }

    public string? HName { get; set; }

    public string? HSdt { get; set; }

    public string? HEmail { get; set; }

    public string? HWebsite { get; set; }

    public string? HDescription { get; set; }

    public int? HTotalRoom { get; set; }

    public int? HFloorCount { get; set; }

    public string? HAddress { get; set; }

    public string? HZip { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
