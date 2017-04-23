using Bs.Data;
using Bs.Data.Model;

namespace Bs.Business
{
    public class OStudentInsert : Operation<Student>
    {
        private readonly Student Student;
        private readonly StudentAddress Address;

        public OStudentInsert(Student student, StudentAddress address)
        {
            Student = student;
            Address = address;
        }

        protected override void DoJob()
        {
            opResult.Data = genericRepository.Add(Student);
            //genericRepository.Add(Address);

            //var user = new Student
            //{
            //    StudentName = "Ere",
            //    Height = 1,
            //    Weight = 3,
            //    StandardId = stad.Guid

            //};
            //opResult.Data = genericRepository.Add(user);
        }
    }

    public class OStudentGet : Operation<Student>
    {
        private readonly long Id;

        public OStudentGet(long id)
        {
            Id = id;
        }

        protected override void DoJob()
        {
            opResult.Data = genericRepository.GetById<Student>(Id);
        }
    }

    public class OUserByTvf : Operation<Student>
    {
        protected override void DoJob()
        {
            //List<User> omer = dbContext.Database.SqlQuery<User>("SELECT * from dbo.GetUseById({0})", 1).ToList();
        }
    }

    public class OUserBySp : Operation<Student>
    {
        protected override void DoJob()
        {
            //var clientIdParameter = new SqlParameter("@UserId", 1);
            //List<User> omer = dbContext.Database.SqlQuery<User>("GetUserById @UserId", clientIdParameter).ToList();
        }
    }

    public class OStudentDelete : Operation<Student>
    {
        private readonly Student Student            ;

        public OStudentDelete(Student student)
        {
            Student = student;
        }

        protected override void DoJob()
        {
            genericRepository.Delete<Student>(Student);
        }
    }

    public class OStudentUpdate : Operation<Student>
    {
        private readonly Student Emp;

        public OStudentUpdate(Student emp)
        {
            Emp = emp;
        }

        protected override void DoJob()
        {
            genericRepository.Update<Student>(Emp);
        }
    }
}