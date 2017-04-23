using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bs.Data.Model.BaseModel
{
    public class BaseEntityModel
    {
        [Column(Order = 1), Key]
        public long Guid { get; set; }

        [Column(Order = 2)]
        public int IsDeleted { get; set; }

        [Column(Order = 3), ConcurrencyCheck]
        public long LastUpdated { get; set; }
    }
}