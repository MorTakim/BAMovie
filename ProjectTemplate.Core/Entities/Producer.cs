using ProjectTemplate.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Core.Entities
{
    public class Producer : IEntityKey<int>
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ChairManName { get; set; }
        public DateTime FormDate { get; set; }
        public string WebSite { get; set; }
        public string CompanyAddress { get; set; }


        public virtual ICollection<Film> Movies { get; set; }
    }
}
