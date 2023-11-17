using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Framework_Test.Server.Models;

public partial class Service
{
    [Key]
    public int SId { get; set; }

    public string? SName { get; set; }

    public string? SDescription { get; set; }

    public decimal? SCost { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Servicesbooked> Servicesbookeds { get; set; } = new List<Servicesbooked>();
}
