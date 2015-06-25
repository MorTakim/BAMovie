using System.Data.Entity.Migrations;

namespace ProjectTemplate.Core.EF
{
    public class ProjectTemplateConfiguration : DbMigrationsConfiguration<ProjectTemplateContext>
    {
        public ProjectTemplateConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}