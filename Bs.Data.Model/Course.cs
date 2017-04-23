using Bs.Data.Model.BaseModel;
using System.Collections.Generic;

namespace Bs.Data.Model
{
    public class Course : BaseEntityModel
    {
        public string CourseName { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}