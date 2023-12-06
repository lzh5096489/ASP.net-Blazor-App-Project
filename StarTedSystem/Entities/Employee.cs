using System;
using System.Collections.Generic;

namespace StarTedSystem.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateHired { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public int PositionId { get; set; }

    public int ProgramId { get; set; }

    public string? LoginId { get; set; }

    public virtual ICollection<Club> Clubs { get; set; } = new List<Club>();
}
