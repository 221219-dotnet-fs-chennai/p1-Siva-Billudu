﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public interface ICRepo<T>
    {
        T AddCompany(T TrCompany);

        List<T> GetAllSivaCompany();

    }
}