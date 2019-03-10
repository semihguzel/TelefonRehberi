using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.BLL.Repository.Concrete;
using TelefonRehberi.DATA.Entities;

namespace TelefonRehberi.BLL.Controls
{
    public static class DepartmanKontrol
    {
        public static bool DepartmanSil(Departman departman)
        {
            CalisanDetayConcrete calisanDetayConcrete = new CalisanDetayConcrete();
            var bolumdeCalisanSayisi = calisanDetayConcrete._calisanDetayRepository.GetEntity().Where(x => x.DepartmanID == departman.DepartmanID).Count();
            if (bolumdeCalisanSayisi > 0)
                return false;
            else
                return true;
        }
    }
}
