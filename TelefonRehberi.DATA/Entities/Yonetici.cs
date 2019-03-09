using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.DATA.Entities
{
    public class Yonetici
    {
        public int YoneticiID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public bool AktifMi { get; set; }
    }
}
