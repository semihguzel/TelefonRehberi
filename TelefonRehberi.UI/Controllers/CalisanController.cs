using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.BLL.Repository.Concrete;
using TelefonRehberi.DATA.Entities;

namespace TelefonRehberi.UI.Controllers
{
    public class CalisanController : Controller
    {
        CalisanConcrete calisanConcrete;
        CalisanDetayConcrete calisanDetayConcrete;
        public ActionResult CalisanDetayi(int id)
        {
            //TODO : View'i yapilmadi
            calisanDetayConcrete = new CalisanDetayConcrete();
            var calisan = calisanDetayConcrete._calisanDetayRepository.GetById(id);
            return View(calisan);
        }
        [HttpGet]
        public ActionResult CalisanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalisanEkle(FormCollection frm)
        {
            Calisan calisan = new Calisan()
            {
                CalisanAdi = frm["name"],
                CalisanSoyadi = frm["surname"],
                Telefon = frm["telephone"]
            };

            CalisanDetay calisanDetay = new CalisanDetay()
            {
                Cinsiyet = frm["gender"] == "false" ? false : true,
                Adres = frm["address"],
                DepartmanID = int.Parse(frm["departmentId"]),
                YetkiID = int.Parse(frm["authorizationId"]),
            };
            calisanDetay.CalisanID = calisan.CalisanID;
            if (calisan.Telefon.Length > 13)
            {
                return RedirectToAction("CalisanEkle");
            }
            else
            {
                calisanConcrete = new CalisanConcrete();
                calisanDetayConcrete = new CalisanDetayConcrete();

                calisanConcrete._calisanRepository.Insert(calisan);
                calisanConcrete._calisanUnitOfWork.SaveChanges();
                calisanConcrete._calisanUnitOfWork.Dispose();

                calisanDetayConcrete._calisanDetayRepository.Insert(calisanDetay);
                calisanDetayConcrete._calisanDetayUnitOfWork.SaveChanges();
                calisanDetayConcrete._calisanDetayUnitOfWork.Dispose();

                return RedirectToAction("Index", "Yonetici");
            }
        }
    }
}