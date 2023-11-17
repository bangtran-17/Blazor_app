using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Framework_Test.Server.Models;

public partial class Feedback
{
    [Key]
    public int FId { get; set; }

    public string? FDescription { get; set; }

    public DateTime? FDate { get; set; }

    public int? FRate { get; set; }

    public int? GId { get; set; }

    public int? BId { get; set; }

    public string? Status { get; set; }

    public virtual Booking? BIdNavigation { get; set; }

    public virtual Guest? GIdNavigation { get; set; }
}
