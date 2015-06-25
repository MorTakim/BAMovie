using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Core.FluentMappings
{
    public class FilmMap : EntityTypeConfiguration<Film>
    {
        public FilmMap()
        {

            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(40);

            Property(t => t.PublishDate)
                .IsRequired();

            Property(t => t.Website)
                .HasMaxLength(50);

            //farkli tablo ismi verilmek istenirse
            ToTable("Film");

            ////farkli kolon ismi verilmek istenirse
            //Property(t => t.Id).HasColumnName("FilmId");
        }
    }
}
