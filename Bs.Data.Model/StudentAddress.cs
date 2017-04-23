using Bs.Data.Model.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bs.Data.Model
{
    public class StudentAddress : BaseEntityModel
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public long StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}