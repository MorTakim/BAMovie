using System.Collections.Generic;
using ProjectTemplate.Core.Abstractions.Business;
using ProjectTemplate.Core.Abstractions.Repository;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Core.Repository;

namespace ProjectTemplate.Business
{
    public class BusinessStudent : BusinessBase<Student>, IBusinessStudent
    {
        private readonly IRepositoryStudent _repositoryStudent;

        public BusinessStudent(IRepositoryBase<Student> repositoryBase, IUnitOfWork uow, IRepositoryStudent repositoryStudent)
            : base(repositoryBase, uow)
        {
            _repositoryStudent = repositoryStudent;
        }

        public IEnumerable<Student> GetStudentsByLastname(string lastname)
        {
            lastname = lastname.Trim();

            return _repositoryStudent.GetStudentsByLastname(lastname);
        }


        /* TRANSACTIONAL bir işlem varsa BeginTransaction ve Commit kullanın !!!!!
        void Test()
        {
            try
            {
                Uow.BeginTransaction();

                //..... do work
                //..... do work
                //..... do work

                Uow.Commit();
            }
            catch
            {
                Uow.Rollback();
            }
        }
        */
    }
}