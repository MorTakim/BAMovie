using ProjectTemplate.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Core.Entities
{
    public class Director:IEntityKey<int>,PersonBase
    {

        public int Id {get;set; }
        public string ImagePath { get; set; }
        public virtual ICollection<Film> DirectorFilms { get; set; }
        public override string ToString()
        {
            return Name + ' ' + SurName;
        }
        


       
    }
}
