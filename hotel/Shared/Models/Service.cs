﻿using System;
using System.Collections.Generic;

namespace Hotel.Shared.Models;

public partial class Service
{
    public int SId { get; set; }

    public string? SName { get; set; }

    public string? SDescription { get; set; }

    public decimal? SCost { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Servicesbooked> Servicesbookeds { get; } = new List<Servicesbooked>();
}
