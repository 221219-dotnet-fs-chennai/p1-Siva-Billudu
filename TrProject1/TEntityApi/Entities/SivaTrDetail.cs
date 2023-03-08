using System;
using System.Collections.Generic;

namespace TEntityApi.Entities;

public partial class SivaTrDetail
{
    public int TrId { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Fullname { get; set; }

    public string? Phone { get; set; }

    public string? Website { get; set; }

    public string? Gender { get; set; }

    public virtual SivaTrContact? SivaTrContact { get; set; }

    public virtual ICollection<SivaTrEducation> SivaTrEducations { get; } = new List<SivaTrEducation>();

    public virtual ICollection<SivaTrSkill> SivaTrSkills { get; } = new List<SivaTrSkill>();

    public virtual ICollection<SivaTrcompany> SivaTrcompanies { get; } = new List<SivaTrcompany>();
}
