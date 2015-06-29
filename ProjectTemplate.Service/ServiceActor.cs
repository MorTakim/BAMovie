using ProjectTemplate.Core.Abstractions.Business;
using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Service
{
    public class ServiceActor : ServiceBase<Actor>, IServiceActor
    {
        private readonly IBusinessActor _businessActor;
        public ServiceActor(IBusinessBase<Actor> businessBase, IBusinessActor businessActor)
            : base(businessBase)
        {
            _businessActor = businessActor;
        }
    }
}
