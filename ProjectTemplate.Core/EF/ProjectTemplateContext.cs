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

        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<FilmType> FilmTypes { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Writer> Writers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //gerekli ise
            modelBuilder.Configurations.Add(new ActorMap());
            modelBuilder.Configurations.Add(new DirectorMap());
            modelBuilder.Configurations.Add(new FilmMap());
            modelBuilder.Configurations.Add(new FilmTypeMap());
            modelBuilder.Configurations.Add(new ProducerMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new WriterMap());
        }
    }
}
