using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Framework_Test.Server.Models;

public partial class Department
{
    [Key]
    public int DeId { get; set; }

    public string? DeName { get; set; }

    public string? DeDescription { get; set; }

    public decimal? DeInitialSalary { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
