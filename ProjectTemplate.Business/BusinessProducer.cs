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
    public class BusinessProducer : BusinessBase<Producer>, IBusinessProducer
    {
        public BusinessProducer(IRepositoryBase<Producer> repository, IUnitOfWork uow)
            : base(repository, uow)
        {
        }
    }
}
