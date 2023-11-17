using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Framework_Test.Server.Models;

public partial class Hotel
{
    [Key]
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

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
