using System;
using System.Collections.Generic;

namespace TEntityApi.Entities;

public partial class SivaTrSkill
{
    public int Sid { get; set; }

    public string? Skill { get; set; }

    public int Trskillid { get; set; }

    public virtual SivaTrDetail Trskill { get; set; } = null!;
}
