using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Data.Model
{
    public class Bolge
    {
        public int BolgeId { get; set; }

        public string BolgeAdi { get; set; }

        public virtual ICollection<Personel> Personel { get; set; }


    }
}
