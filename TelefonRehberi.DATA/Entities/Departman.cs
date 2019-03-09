using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.DATA.Entities
{
    public class Departman
    {
        public int DepartmanID { get; set; }
        public string DepartmanAdi { get; set; }
        public string Aciklama { get; set; }

        public List<CalisanDetay> CalisanDetaylari { get; set; }
    }
}
