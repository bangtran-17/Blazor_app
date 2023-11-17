using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Framework_Test.Server.Models;

public partial class Servicesbooked
{
    [Key]
    public int SId { get; set; }

    public int BId { get; set; }

    public string? Status { get; set; }

    public virtual Booking BIdNavigation { get; set; } = null!;

    public virtual Service SIdNavigation { get; set; } = null!;
}
