﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clothing22store.Db;
namespace Clothing22store.EF
{
    public class UserDataClas
    {
        public static Entities Context { get; } = new Entities();
    }
}
