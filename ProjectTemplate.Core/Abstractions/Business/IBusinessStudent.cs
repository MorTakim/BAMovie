using System.Collections.Generic;
using ProjectTemplate.Core.Entities;

namespace ProjectTemplate.Core.Abstractions.Business
{
    public interface IBusinessStudent : IBusinessBase<Student>
    {
        IEnumerable<Student> GetStudentsByLastname(string lastname); 
    }
}