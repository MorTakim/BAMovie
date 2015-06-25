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
    public class ServiceWriter : ServiceBase<Writer>, IServiceWriter
    {
        private readonly IBusinessWriter _businessWriter;

        public ServiceWriter(IBusinessBase<Writer> businessBase, IBusinessWriter businessWriter)
            : base(businessBase)
        {
            _businessWriter = businessWriter;
        }
    }
}