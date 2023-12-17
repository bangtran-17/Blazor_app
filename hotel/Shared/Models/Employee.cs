using System;
using System.Collections.Generic;
using Hotel.Shared.Models;

namespace Hotel.Shared.Models;

public partial class Employee
{
    public int EId { get; set; }

    public string? EFirstName { get; set; }

    public string? ELastName { get; set; }

    public string? EDesignation { get; set; }

    public string? EContactNumber { get; set; }

    public string? EEmail { get; set; }

    public DateTime? EJoinDate { get; set; }

    public string? EAddress { get; set; }

    public int? DeId { get; set; }

    public int? HId { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual Department? De { get; set; }

    public virtual Hotel1? HIdNavigation { get; set; }

    public virtual ICollection<Salary> Salaries { get; } = new List<Salary>();
}
