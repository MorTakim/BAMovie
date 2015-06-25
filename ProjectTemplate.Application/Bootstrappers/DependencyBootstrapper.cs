using System.Data.Entity;
using ProjectTemplate.Business;
using ProjectTemplate.Core.Abstractions.Business;
using ProjectTemplate.Core.Abstractions.Repository;
using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.EF;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Core.IoC;
using ProjectTemplate.Core.Repository;
using ProjectTemplate.Repository;
using ProjectTemplate.Service;

namespace ProjectTemplate.Application.Bootstrappers
{
    /// <summary>
    /// Dependency bootstrapper
    /// </summary>
    public class DependencyBootstrapper : IBootstrapper
    {
        /// <summary>
        /// Bootstraps dependencies
        /// </summary>
        /// <param name="dependencyContainer"></param>
        public virtual void Bootstrap(IDependencyContainer dependencyContainer)
        {
           
        
            dependencyContainer.RegisterTransient<IUnitOfWork, EFUnitOfWork>();
            dependencyContainer.RegisterTransient<IRepository, EFRepository>();
            dependencyContainer.RegisterTransient<DbContext, ProjectTemplateContext>();

            dependencyContainer.RegisterTransient<IServiceBase<Film>, ServiceBase<Film>>();
            dependencyContainer.RegisterTransient<IRepositoryBase<Film>, RepositoryBase<Film>>();
            dependencyContainer.RegisterTransient<IBusinessBase<Film>, BusinessBase<Film>>();
            dependencyContainer.RegisterTransient<IServiceFilm, ServiceFilm>();
            dependencyContainer.RegisterTransient<IRepositoryFilm, RepositoryFilm>();
            dependencyContainer.RegisterTransient<IBusinessFilm, BusinessFilm>();

            dependencyContainer.RegisterTransient<IServiceBase<Actor>, ServiceBase<Actor>>();
            dependencyContainer.RegisterTransient<IRepositoryBase<Actor>, RepositoryBase<Actor>>();
            dependencyContainer.RegisterTransient<IBusinessBase<Actor>, BusinessBase<Actor>>();
            dependencyContainer.RegisterTransient<IServiceActor, ServiceActor>();
            dependencyContainer.RegisterTransient<IRepositoryActor, RepositoryActor>();
            dependencyContainer.RegisterTransient<IBusinessActor, BusinessActor>();

            dependencyContainer.RegisterTransient<IServiceBase<Director>, ServiceBase<Director>>();
            dependencyContainer.RegisterTransient<IRepositoryBase<Director>, RepositoryBase<Director>>();
            dependencyContainer.RegisterTransient<IBusinessBase<Director>, BusinessBase<Director>>();
            dependencyContainer.RegisterTransient<IServiceDirector, ServiceDirector>();
            dependencyContainer.RegisterTransient<IRepositoryDirector, RepositoryDirector>();
            dependencyContainer.RegisterTransient<IBusinessDirector, BusinessDirector>();

            dependencyContainer.RegisterTransient<IServiceBase<FilmType>, ServiceBase<FilmType>>();
            dependencyContainer.RegisterTransient<IRepositoryBase<FilmType>, RepositoryBase<FilmType>>();
            dependencyContainer.RegisterTransient<IBusinessBase<FilmType>, BusinessBase<FilmType>>();
            dependencyContainer.RegisterTransient<IServiceFilmType, ServiceFilmType>();
            dependencyContainer.RegisterTransient<IRepositoryFilmType, RepositoryFilmType>();
            dependencyContainer.RegisterTransient<IBusinessFilmType, BusinessFilmType>();

            dependencyContainer.RegisterTransient<IServiceBase<Producer>, ServiceBase<Producer>>();
            dependencyContainer.RegisterTransient<IRepositoryBase<Producer>, RepositoryBase<Producer>>();
            dependencyContainer.RegisterTransient<IBusinessBase<Producer>, BusinessBase<Producer>>();
            dependencyContainer.RegisterTransient<IServiceProducer, ServiceProducer>();
            dependencyContainer.RegisterTransient<IRepositoryProducer, RepositoryProducer>();
            dependencyContainer.RegisterTransient<IBusinessProducer, BusinessProducer>();

            dependencyContainer.RegisterTransient<IServiceBase<User>, ServiceBase<User>>();
            dependencyContainer.RegisterTransient<IRepositoryBase<User>, RepositoryBase<User>>();
            dependencyContainer.RegisterTransient<IBusinessBase<User>, BusinessBase<User>>();
            dependencyContainer.RegisterTransient<IServiceUser, ServiceUser>();
            dependencyContainer.RegisterTransient<IRepositoryUser, RepositoryUser>();
            dependencyContainer.RegisterTransient<IBusinessUser, BusinessUser>();

            dependencyContainer.RegisterTransient<IServiceBase<Writer>, ServiceBase<Writer>>();
            dependencyContainer.RegisterTransient<IRepositoryBase<Writer>, RepositoryBase<Writer>>();
            dependencyContainer.RegisterTransient<IBusinessBase<Writer>, BusinessBase<Writer>>();
            dependencyContainer.RegisterTransient<IServiceWriter, ServiceWriter>();
            dependencyContainer.RegisterTransient<IRepositoryWriter, RepositoryWriter>();
            dependencyContainer.RegisterTransient<IBusinessWriter, BusinessWriter>();

        }
    }
}
