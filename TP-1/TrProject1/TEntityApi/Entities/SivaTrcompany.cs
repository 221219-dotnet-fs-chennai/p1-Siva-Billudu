using System;
using System.Collections.Generic;

namespace TEntityApi.Entities;

public partial class SivaTrcompany
{
    public int Cid { get; set; }

    public string? Cname { get; set; }

    public string? Ctype { get; set; }

    public string? Startyear { get; set; }

    public string? Endyear { get; set; }

    public int Trcompanyid { get; set; }

    public virtual SivaTrDetail Trcompany { get; set; } = null!;
}
