

using System;
using System.Collections.Generic;
using Hotel.Shared.Models;

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

    public int? Rid { get; set; }
    public decimal? BCost { get; set; }

    public int? Rid { get; set; }

    public string? StripeSessionId { get; set; }

    public virtual Discount? DIdNavigation { get; set; }

    public virtual Employee? EIdNavigation { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Guest? GIdNavigation { get; set; }

    public virtual Hotel1? HIdNavigation { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Room? RidNavigation { get; set; }

    public virtual ICollection<Servicesbooked> Servicesbookeds { get; set; } = new List<Servicesbooked>();
}
