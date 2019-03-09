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
        //TODO : View'i yapilmadi
        CalisanConcrete calisanConcrete;
        CalisanDetayConcrete calisanDetayConcrete;
        public ActionResult CalisanDetay(int id)
        {
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

            calisanConcrete = new CalisanConcrete();
            calisanConcrete._calisanRepository.Insert(calisan);
            calisanConcrete._calisanUnitOfWork.SaveChanges();
            calisanConcrete._calisanUnitOfWork.Dispose();

            return RedirectToAction("Index", "Admin");
        }
    }
}