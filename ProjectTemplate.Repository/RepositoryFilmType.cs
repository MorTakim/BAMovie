using ProjectTemplate.Core.Abstractions.Repository;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Repository
{
    public class RepositoryFilmType : RepositoryBase<FilmType>, IRepositoryFilmType
    {
        public RepositoryFilmType(IRepository repository)
            : base(repository)
        {

        }
    }
}
