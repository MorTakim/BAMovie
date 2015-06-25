using ProjectTemplate.Core.Abstractions.Repository;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Core.Repository;

namespace ProjectTemplate.Repository
{
    public class RepositoryFirm : RepositoryBase<Firm>, IRepositoryFirm
    {
        public RepositoryFirm(IRepository repository)
            : base(repository)
        {
        }
    }
}