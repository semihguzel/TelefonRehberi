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
        DepartmanConcrete departmanConcrete;
        YetkiConcrete yetkiConcrete;
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

                calisanDetay.CalisanID = calisan.CalisanID;

                calisanDetayConcrete._calisanDetayRepository.Insert(calisanDetay);
                calisanDetayConcrete._calisanDetayUnitOfWork.SaveChanges();
                calisanDetayConcrete._calisanDetayUnitOfWork.Dispose();

                return RedirectToAction("Index", "Yonetici");
            }
        }

        public ActionResult CalisanDuzenle(int id)
        {
            calisanConcrete = new CalisanConcrete();
            departmanConcrete = new DepartmanConcrete();
            yetkiConcrete = new YetkiConcrete();

            ViewBag.DepartmanListesi = departmanConcrete._departmanRepository.GetAll();
            ViewBag.YetkiListesi = yetkiConcrete._yetkiRepository.GetAll();

            return View(calisanConcrete._calisanRepository.GetById(id));
        }
        [HttpPost]
        public ActionResult CalisanDuzenle(int id, FormCollection frm)
        {
            calisanConcrete = new CalisanConcrete();
            calisanDetayConcrete = new CalisanDetayConcrete();

            var calisan = calisanConcrete._calisanRepository.GetById(Convert.ToInt32(frm["CalisanID"]));

            calisan.CalisanAdi = frm["CalisanAdi"];
            calisan.CalisanSoyadi = frm["CalisanSoyadi"];
            calisan.Telefon = frm["Telefon"];

            var calisanDetay = calisanDetayConcrete._calisanDetayRepository.GetById(calisan.CalisanID);
            if (calisanDetay == null)
                calisanDetay = new CalisanDetay();
            calisanDetay.Cinsiyet = frm["CalisanDetay.Cinsiyet"] == "false" ? false : true;
            calisanDetay.Adres = frm["CalisanDetay.Adres"];
            calisanDetay.DepartmanID = int.Parse(frm["CalisanDetay.DepartmanID"]);
            calisanDetay.YetkiID = int.Parse(frm["CalisanDetay.YetkiID"]);

            if (calisan.Telefon.Length > 13)
            {
                return RedirectToAction("CalisanDuzenle", new { id = calisan.CalisanID });
            }
            else
            {
                if (calisanDetay.CalisanID == 0)
                {
                    calisanDetay.CalisanID = calisan.CalisanID;
                    calisanDetayConcrete._calisanDetayRepository.Insert(calisanDetay);
                }
                calisanConcrete._calisanUnitOfWork.SaveChanges();
                calisanConcrete._calisanUnitOfWork.Dispose();
                calisanDetayConcrete._calisanDetayUnitOfWork.SaveChanges();
                calisanDetayConcrete._calisanDetayUnitOfWork.Dispose();

                return RedirectToAction("Index", "Yonetici");
            }
        }

        public ActionResult CalisanSil(int id)
        {
            calisanConcrete = new CalisanConcrete();
            calisanDetayConcrete = new CalisanDetayConcrete();

            var silinecekCalisan = calisanConcrete._calisanRepository.GetById(id);
            if (silinecekCalisan != null)
            {
                calisanDetayConcrete._calisanDetayRepository.Delete(silinecekCalisan.CalisanID);
                calisanDetayConcrete._calisanDetayUnitOfWork.SaveChanges();
                calisanDetayConcrete._calisanDetayUnitOfWork.Dispose();

                calisanConcrete._calisanRepository.Delete(silinecekCalisan);
                calisanConcrete._calisanUnitOfWork.SaveChanges();
                calisanConcrete._calisanUnitOfWork.Dispose();
            }
            return RedirectToAction("Index", "Yonetici");
        }

    }
}