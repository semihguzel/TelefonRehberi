using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.DATA.Entities
{
    public class Yetki
    {
        public int YetkiID { get; set; }
        public string YetkiAdi { get; set; }

        public virtual List<CalisanDetay> CalisanDetaylari { get; set; }

    }
}
