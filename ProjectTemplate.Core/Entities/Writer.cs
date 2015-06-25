using ProjectTemplate.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Core.Entities
{
    public class Writer : PersonBase, IEntityKey<int>
    {
        public int Id { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}