using ProjectTemplate.Core.Abstractions.Business;
using ProjectTemplate.Core.Abstractions.Repository;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Business
{
    public class BusinessFilmType : BusinessBase<FilmType>, IBusinessFilmType
    {
        private readonly IRepositoryFilmType _repositoryFilmType;

        public BusinessFilmType(IRepositoryBase<FilmType> repository, IUnitOfWork uow, IRepositoryFilmType repositoryFilmType)
            : base(repository, uow)
        {
            _repositoryFilmType = repositoryFilmType;
        }
    }
}
