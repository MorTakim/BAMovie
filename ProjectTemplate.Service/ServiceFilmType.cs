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
    public class ServiceFilmType : ServiceBase<FilmType>, IServiceFilmType
    {
        private readonly IBusinessFilmType _businessFilmType;

        public ServiceFilmType(IBusinessBase<FilmType> business, IBusinessFilmType businessFilmType)
            : base(business)
        {
            _businessFilmType = businessFilmType;
        }
    }
}
