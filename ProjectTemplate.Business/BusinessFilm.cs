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
    public class BusinessFilm : BusinessBase<Film>, IBusinessFilm
    {
        private readonly IRepositoryFilm _repositoryFilm;

        public BusinessFilm(IRepositoryBase<Film> repositoryBase, IUnitOfWork uow, IRepositoryFilm repositoryFilm)
            : base(repositoryBase, uow)
        {
            _repositoryFilm = repositoryFilm;
        }
    }
}
