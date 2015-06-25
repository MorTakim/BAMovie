using ProjectTemplate.Core.Abstractions.Business;
using ProjectTemplate.Core.Abstractions.Repository;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Core.Repository;

namespace ProjectTemplate.Business
{
    public class BusinessFirm : BusinessBase<Firm>, IBusinessFirm
    {
        public BusinessFirm(IRepositoryBase<Firm> repository, IUnitOfWork uow)
            : base(repository, uow)
        {
        }
    }
}