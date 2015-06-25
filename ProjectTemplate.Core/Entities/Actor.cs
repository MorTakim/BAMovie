﻿using ProjectTemplate.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Core.Entities
{

    public class Actor: PersonBase
    {
        public virtual ICollection<Film> Movies { get; set; }
    }
}
