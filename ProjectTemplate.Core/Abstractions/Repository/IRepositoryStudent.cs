using System.Collections.Generic;
using ProjectTemplate.Core.Entities;

namespace ProjectTemplate.Core.Abstractions.Repository
{
    public interface IRepositoryStudent : IRepositoryBase<Student>
    {
        IEnumerable<Student> GetStudentsByLastname(string lastname); 
    }
}
