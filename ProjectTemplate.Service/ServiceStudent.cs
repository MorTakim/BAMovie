using System.Collections.Generic;
using ProjectTemplate.Core.Abstractions.Business;
using ProjectTemplate.Core.Abstractions.Service;
using ProjectTemplate.Core.Entities;

namespace ProjectTemplate.Service
{
    public class ServiceStudent : ServiceBase<Student>, IServiceStudent
    {
        private readonly IBusinessStudent _businessStudent;

        public ServiceStudent(IBusinessBase<Student> businessBase, IBusinessStudent businessStudent)
            : base(businessBase)
        {
            _businessStudent = businessStudent;
        }

        public IEnumerable<Student> GetStudentsByLastname(string lastname)
        {
            return _businessStudent.GetStudentsByLastname(lastname);
        }
    }
}
