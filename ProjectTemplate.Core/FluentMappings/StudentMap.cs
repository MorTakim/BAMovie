using System.Data.Entity.ModelConfiguration;
using ProjectTemplate.Core.Entities;


namespace ProjectTemplate.Core.FluentMappings
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {

        public StudentMap()
        {
            /*
HasKey(t => t.Id);

// Properties
Property(t => t.Firstname)
    .IsRequired()
    .HasMaxLength(20);

Property(t => t.Lastname)
    .IsRequired()
    .HasMaxLength(10);

           
//farkli tablo ismi verilmek istenirse
ToTable("Student");

//farkli kolon ismi verilmek istenirse
Property(t => t.Id).HasColumnName("StudentId");
             */
        }


    }
}
