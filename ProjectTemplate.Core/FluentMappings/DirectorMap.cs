using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Core.FluentMappings
{
    public class DirectorMap : EntityTypeConfiguration<Director>
    {
        public DirectorMap()
        {

            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany<Film>(f => f.Movies).WithMany(a => a.Directors);

            //farkli tablo ismi verilmek istenirse
            ToTable("Director");

            ////farkli kolon ismi verilmek istenirse
            //Property(t => t.Id).HasColumnName("DirectorId");
        }
    }
}
