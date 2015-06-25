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
    public class BusinessActor : BusinessBase<Actor>, IBusinessActor
    {
        private readonly IRepositoryActor _repositoryActor;
        public BusinessActor(IRepositoryBase<Actor> repositoryBase, IUnitOfWork uow, IRepositoryActor repositoryActor)
            : base(repositoryBase, uow)
        {
            _repositoryActor = repositoryActor;
        }
    }
}
