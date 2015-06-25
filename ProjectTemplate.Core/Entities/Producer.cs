using ProjectTemplate.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Core.Entities
{
    public class Producer : IEntityKey<int>
    {
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string ChairManName { get; set; }
        [Required]
        public DateTime FormDate { get; set; }
        [Required]
        public string WebSite { get; set; }
        [Required]
        public string CompanyAddress { get; set; }


        public virtual ICollection<Film> Films { get; set; }
    }
}
