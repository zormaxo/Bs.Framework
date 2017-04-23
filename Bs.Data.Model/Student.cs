using Bs.Data.Model.BaseModel;
using System.Collections.Generic;

namespace Bs.Data.Model
{
    public class Student : BaseEntityModel
    {
        public string StudentName { get; set; }

        public Section Section { get; set; }

        public virtual ICollection<StudentAddress> StudentAddresses { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }

    public enum Section
    {
        Programming,
        Analyst
    }
}