using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.DATA.Entities
{
    public class CalisanDetay
    {
        public int CalisanID { get; set; }
        public bool Cinsiyet { get; set; }
        public string Adres { get; set; }

        public int DepartmanID { get; set; }
        public Departman Departman { get; set; }

        public int YetkiID { get; set; }
        public Yetki Yetki { get; set; }

        public Calisan Calisan { get; set; }
    }
}
