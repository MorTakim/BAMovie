using ProjectTemplate.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Core.Entities
{

    public class Actor:IEntityKey<int>,PersonBase
    {
        public int Id { get; set; }
        public virtual ICollection<Film> Filmler { get; set; }
    }
}
