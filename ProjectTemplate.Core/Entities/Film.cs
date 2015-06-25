using ProjectTemplate.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Core.Entities
{
    public class Film : IEntityKey<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime PublishDate { get; set; }

        public decimal ImdbPoint { get; set; }

        public string PosterImgPath { get; set; }

        public string Website { get; set; }


        // Navigation
        public virtual ICollection<FilmType> FilmTypes { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

        public virtual ICollection<Director> Directors { get; set; }

        public virtual ICollection<Writer> Writers { get; set; }

        public virtual ICollection<Producer> Producers { get; set; }
        
    }
}
