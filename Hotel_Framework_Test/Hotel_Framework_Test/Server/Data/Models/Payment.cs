using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Framework_Test.Server.Models;

public partial class Payment
{
    [Key]
    public int PId { get; set; }

    public string? PStatus { get; set; }

    public string? PType { get; set; }

    public DateTime? PDatCoc { get; set; }

    public decimal? PAmout { get; set; }

    public int? BId { get; set; }

    public string? Status { get; set; }

    public virtual Booking? BIdNavigation { get; set; }
}
