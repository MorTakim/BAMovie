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
    public class BusinessWriter : BusinessBase<Writer>, IBusinessWriter
    {
        private readonly IRepositoryWriter _repositoryWriter;

        public BusinessWriter(IRepositoryBase<Writer> repositoryBase, IUnitOfWork uow, IRepositoryWriter repositoryWriter)
            : base(repositoryBase, uow)
        {
            _repositoryWriter = repositoryWriter;
        }
    }
}