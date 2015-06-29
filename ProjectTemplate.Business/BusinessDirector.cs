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
    public class BusinessDirector: BusinessBase<Director>, IBusinessDirector
    {
        private readonly IRepositoryDirector _repositoryDirector; 
        public BusinessDirector(IRepositoryBase<Director> repository, IUnitOfWork uow,IRepositoryDirector repositoryDirector)
            : base(repository, uow)
        {
            _repositoryDirector = repositoryDirector;
        }
    
    }
}
