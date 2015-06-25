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
    public class ServiceFilm : ServiceBase<Film>, IServiceFilm
    {
        private readonly IBusinessFilm _businessFilm;

        public ServiceFilm(IBusinessBase<Film> businessBase, IBusinessFilm businessFilm)
            : base(businessBase)
        {
            _businessFilm = businessFilm;
        }
    }
}
