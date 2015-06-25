using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Core.FluentMappings
{
    public class FilmTypeMap : EntityTypeConfiguration<FilmType>
    {
        public FilmTypeMap()
        {

            HasKey(t => t.Id);

            // Properties
            Property(t => t.TypeName)
                .IsRequired()
                .HasMaxLength(20);

            //farkli tablo ismi verilmek istenirse
            ToTable("FilmType");

            ////farkli kolon ismi verilmek istenirse
            //Property(t => t.Id).HasColumnName("FilmTypeId");
        }
    }
}
