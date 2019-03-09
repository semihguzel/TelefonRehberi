using System;
using System.Collections.Generic;
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

        public CalisanDetay CalisanDetay { get; set; }
    }
}
