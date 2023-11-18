using System;
using System.Collections.Generic;

namespace Hotel.Shared.Models;

public partial class Salary
{
    public int SalaryId { get; set; }

    public int? EId { get; set; }

    public decimal? Salary1 { get; set; }

    public DateTime? SalaryDate { get; set; }

    public string? Status { get; set; }

    public virtual Employee? EIdNavigation { get; set; }
}
