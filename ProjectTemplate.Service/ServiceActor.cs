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
         public ServiceActor(IBusinessBase<Actor> business)
            : base(business)
        {
        }
    }
}
