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
    public class FilmMap : EntityTypeConfiguration<Film>
    {
        public FilmMap()
        {

            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(40);

            Property(t => t.PublishDate)
                .IsRequired();

            Property(t => t.Website)
                .HasMaxLength(50);

            HasMany<Actor>(f => f.Actors).WithMany(a => a.Movies);
            HasMany<Director>(f => f.Directors).WithMany(a => a.Movies);
            HasMany<Writer>(f => f.Writers).WithMany(a => a.Movies);
            HasMany<Producer>(f => f.Producers).WithMany(a => a.Movies);
            HasMany<FilmType>(f => f.FilmTypes).WithMany(a => a.Movies);

            //farkli tablo ismi verilmek istenirse
            ToTable("Film");

            ////farkli kolon ismi verilmek istenirse
            //Property(t => t.Id).HasColumnName("FilmId");
        }
    }
}
