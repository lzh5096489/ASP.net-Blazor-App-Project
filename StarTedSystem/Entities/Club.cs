using System;
using System.Collections.Generic;

namespace StarTedSystem.Entities;

public partial class Club
{
    public string ClubId { get; set; } = null!;

    public string ClubName { get; set; } = null!;

    public bool Active { get; set; }

    public int? EmployeeId { get; set; }

    public decimal Fee { get; set; }

    public virtual Employee? Employee { get; set; }
}
