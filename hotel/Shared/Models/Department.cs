using System;
using System.Collections.Generic;

namespace Hotel.Shared.Models;

public partial class Department
{
    public int DeId { get; set; }

    public string? DeName { get; set; }

    public string? DeDescription { get; set; }

    public decimal? DeInitialSalary { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
