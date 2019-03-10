using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.DATA.Entities
{
    public class Calisan
    {
        public int CalisanID { get; set; }
        public string CalisanAdi { get; set; }
        public string CalisanSoyadi { get; set; }
        public string Telefon { get; set; }

        [ForeignKey("Calisanlar")]
        public int UstCalisanID { get; set; }
        public virtual Calisan UstCalisan { get; set; }


        public virtual CalisanDetay CalisanDetay { get; set; }
        public virtual ICollection<Calisan> Calisanlar { get; set; }
    }
}
