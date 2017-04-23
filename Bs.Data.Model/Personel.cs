using System.ComponentModel.DataAnnotations.Schema;

namespace Bs.Data.Model
{
    public class Personel
    {
        public int PersonelId { get; set; }

        public int BolgeId { get; set; }

        [ForeignKey("BolgeId")]
        public virtual Bolge Bolge { get; set; }
    }
}