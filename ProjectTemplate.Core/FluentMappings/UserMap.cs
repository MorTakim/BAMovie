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
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {

            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            Property(t => t.Email)
                .IsRequired();


            //farkli tablo ismi verilmek istenirse
            ToTable("User");

            ////farkli kolon ismi verilmek istenirse
            //Property(t => t.Id).HasColumnName("UserId");
        }
    }
}
