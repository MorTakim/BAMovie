using ProjectTemplate.Core.Abstractions.Business;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Repository
{
   public class RepositoryActor : RepositoryBase<Actor>, IRepositoryActor
    {
        public RepositoryActor(IRepository repository)
            : base(repository)
        {

        }
    }
}
