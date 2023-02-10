using System;
using System.Collections.Generic;

namespace TEntityApi.Entities;

public partial class SivaTrEducation
{
    public int Eid { get; set; }

    public string? Tuniversity { get; set; }

    public string? HdegreeName { get; set; }

    public string? Cgpa { get; set; }

    public string? Startdate { get; set; }

    public string? PassoutDate { get; set; }

    public int TrEduid { get; set; }

    public virtual SivaTrDetail TrEdu { get; set; } = null!;
}
