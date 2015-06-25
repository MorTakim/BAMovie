using System.Collections.Generic;
using ProjectTemplate.Core.Entities;

namespace ProjectTemplate.Core.Abstractions.Service
{
    public interface IServiceStudent : IServiceBase<Student>
    {
        IEnumerable<Student> GetStudentsByLastname(string lastname); 
    }
}