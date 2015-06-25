using ProjectTemplate.Core.Abstractions.Business;
using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.Entities;

namespace ProjectTemplate.Service
{
    public class ServiceFirm : ServiceBase<Firm>, IServiceFirm
    {
        public ServiceFirm(IBusinessBase<Firm> business)
            : base(business)
        {
        }
    }
}