using System.Data.Entity;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Core.FluentMappings;

namespace ProjectTemplate.Core.EF
{
    public class ProjectTemplateContext : DbContext
    {
        public ProjectTemplateContext()
            : base("ProjectTemplateContext")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<ProjectTemplateContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProjectTemplateContext, ProjectTemplateConfiguration>());
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Firm> Firms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //gerekli ise
            //modelBuilder.Configurations.Add(new StudentMap());
        }
    }
}
