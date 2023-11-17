using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Framework_Test.Server.Models;

public partial class Booking
{
    [Key]
    public int BId { get; set; }

    public DateTime? BDate { get; set; }

    public int? BStayDuration { get; set; }

    public DateTime? BCheckingDate { get; set; }

    public DateTime? BCheckoutDate { get; set; }

    public decimal? BAmount { get; set; }

    public int? HId { get; set; }

    public int? EId { get; set; }

    public int? GId { get; set; }

    public int? DId { get; set; }

    public string? BStatus { get; set; }

    public virtual Discount? DIdNavigation { get; set; }

    public virtual Employee? EIdNavigation { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Guest? GIdNavigation { get; set; }

    public virtual Hotel? HIdNavigation { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Servicesbooked> Servicesbookeds { get; set; } = new List<Servicesbooked>();

    public virtual ICollection<Room> RIds { get; set; } = new List<Room>();
}
