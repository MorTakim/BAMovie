using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Core.FluentMappings
{
    public class ProducerMap : EntityTypeConfiguration<Producer>
    {
        public ProducerMap()
        {

            HasKey(t => t.Id);

            // Properties
            Property(t => t.CompanyName)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.FormDate)
                .IsRequired();

            Property(t => t.CompanyAddress)
                .IsRequired();


            //farkli tablo ismi verilmek istenirse
            ToTable("Producer");

            ////farkli kolon ismi verilmek istenirse
            //Property(t => t.Id).HasColumnName("ProducerId");
        }
    }
}
