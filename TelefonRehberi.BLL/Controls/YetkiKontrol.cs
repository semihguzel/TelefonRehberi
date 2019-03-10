using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.BLL.Enums;
using TelefonRehberi.BLL.Repository.Concrete;
using TelefonRehberi.DATA.Entities;

namespace TelefonRehberi.BLL.Controls
{
    public static class YetkiKontrol
    {
        public static bool KullaniciSil(Calisan calisan)
        {
            CalisanDetayConcrete calisanDetayConcrete = new CalisanDetayConcrete();

            if (calisan.CalisanDetay != null)
            {
                if (calisan.CalisanDetay.Yetki.YetkiAdi == "Müdür")
                {
                    int altCalisanSayisi = calisanDetayConcrete._calisanDetayRepository.GetEntity().Where(x => x.DepartmanID == calisan.CalisanDetay.DepartmanID && x.Yetki.YetkiAdi != calisan.CalisanDetay.Yetki.YetkiAdi).Count();
                    if (altCalisanSayisi > 0)
                        return false;
                    else
                        return true;
                }
                else if (calisan.CalisanDetay.Yetki.YetkiAdi == "Uzman")
                {
                    int altCalisanSayisi = calisanDetayConcrete._calisanDetayRepository.GetEntity().Where(x => x.DepartmanID == calisan.CalisanDetay.DepartmanID && x.Yetki.YetkiAdi == "Stajyer").Count();
                    if (altCalisanSayisi > 0)
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            }
            else
            {
                return true;
            }
        }
    }
}
