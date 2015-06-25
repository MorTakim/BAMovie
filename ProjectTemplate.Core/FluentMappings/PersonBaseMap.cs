using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Core.FluentMappings
{
    public class PersonBaseMap : EntityTypeConfiguration<PersonBase>
    {
        public PersonBaseMap()
        {
            // Properties
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.SurName)
                .IsRequired()
                .HasMaxLength(20);


            //farkli tablo ismi verilmek istenirse
            ToTable("PersonBase");

            ////farkli kolon ismi verilmek istenirse
            //Property(t => t.Id).HasColumnName("PersonBaseId");
        }
    }
            
}
