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
    public class ServiceDirector: ServiceBase<Director>, IServiceDirector
    {
        public ServiceDirector(IBusinessBase<Director> business)
            : base(business)
        {

        }
    }
}
