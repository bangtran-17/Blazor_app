using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Framework_Test.Server.Models;

public partial class Salary
{
    [Key]
    public int SalaryId { get; set; }

    public int? EId { get; set; }

    public decimal? Salary1 { get; set; }

    public DateTime? SalaryDate { get; set; }

    public string? Status { get; set; }

    public virtual Employee? EIdNavigation { get; set; }
}
