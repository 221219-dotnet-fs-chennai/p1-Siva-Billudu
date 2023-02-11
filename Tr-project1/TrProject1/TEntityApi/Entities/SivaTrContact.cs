using System;
using System.Collections.Generic;

namespace TEntityApi.Entities;

public partial class SivaTrContact
{
    public int Lid { get; set; }

    public string Pincode { get; set; } = null!;

    public string? City { get; set; }

    public int Cid { get; set; }

    public virtual SivaTrDetail CidNavigation { get; set; } = null!;
}
