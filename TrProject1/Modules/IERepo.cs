﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public interface IERepo<T>
    {
        T AddEducation(T TrEducation);

        List<T> GetAllSivaEducation();

        T Update(T TrEducation);

        T Remove(string Tuniversity);

    }
}
