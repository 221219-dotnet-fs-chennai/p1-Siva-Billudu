using System;
using System.Collections.Generic;

namespace MinimalAPI.Entities;

public partial class SivaTrDetail
{
    public int TrId { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Fullname { get; set; }

    public string? Phone { get; set; }

    public string? Website { get; set; }

    public string? Gender { get; set; }
}
