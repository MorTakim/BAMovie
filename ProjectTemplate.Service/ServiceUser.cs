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
    public class ServiceUser : ServiceBase<User>, IServiceUser
    {
        private readonly IBusinessUser _businessUser;

        public ServiceUser(IBusinessBase<User> businessBase, IBusinessUser businessUser)
            : base(businessBase)
        {
            _businessUser = businessUser;
        }

        public User LoginControl(string eMail, string password)
        {
            return _businessUser.LoginControl(eMail, password);
        }
    }
}
