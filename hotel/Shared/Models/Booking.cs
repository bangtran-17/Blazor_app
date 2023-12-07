using System;
using System.Collections.Generic;

namespace Hotel.Shared.Models;

public partial class Booking
{
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

    public virtual ICollection<Feedback>? Feedbacks { get; } = new List<Feedback>();

    public virtual Guest? GIdNavigation { get; set; }

    public virtual Hotel1? HIdNavigation { get; set; }

    public virtual ICollection<Payment>? Payments { get; } = new List<Payment>();

    public virtual ICollection<Servicesbooked>? Servicesbookeds { get; } = new List<Servicesbooked>();

    public virtual ICollection<Room>? RIds { get; } = new List<Room>();
}
