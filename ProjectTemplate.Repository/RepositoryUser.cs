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
    public class RepositoryUser: RepositoryBase<User>, IRepositoryUser
    {
        public RepositoryUser(IRepository repository)
            : base(repository)
        {
        }

        public User LoginControl(string eMail, string password)
        {
            return (Repository.Select<User>().FirstOrDefault(s => s.Email == eMail && s.Password == password));
        }
    }
}
