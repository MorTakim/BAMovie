using System.Collections.Generic;
using System.Linq;
using ProjectTemplate.Core.Abstractions.Repository;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Core.Repository;

namespace ProjectTemplate.Repository
{
    public class RepositoryStudent : RepositoryBase<Student>, IRepositoryStudent
    {
        public RepositoryStudent(IRepository repository)
            : base(repository)
        {
        }

        public IEnumerable<Student> GetStudentsByLastname(string lastname)
        {
            return Repository.Select<Student>().Where(x => x.Lastname == lastname);
        }
    }
}
