using ProjectTemplate.Core.Abstractions.Business;
using ProjectTemplate.Core.Abstractions.Repository;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Business
{
    public class BusinessUser : BusinessBase<User>, IBusinessUser
    {
        private readonly IRepositoryUser _repositoryUser;

        public BusinessUser(IRepositoryBase<User> repositoryBase, IUnitOfWork uow, IRepositoryUser repositoryUser)
            : base(repositoryBase, uow)
        {
            _repositoryUser = repositoryUser;
        }

        public User LoginControl(string eMail, string password)
        {
            return _repositoryUser.LoginControl(eMail, password);
        }
    }
}
