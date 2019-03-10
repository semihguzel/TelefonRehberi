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
        public ActionResult CalisanDetayi(int id)
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
            Calisan calisan = new Calisan();
            calisan.CalisanAdi = frm["name"];
            calisan.CalisanSoyadi = frm["surname"];
            calisan.Telefon = frm["telephone"];
            if (frm["authorizationId"] != "")
                calisan.UstCalisanID = Convert.ToInt32(frm["authorizationId"]);

            CalisanDetay calisanDetay = new CalisanDetay()
            {
                Cinsiyet = frm["gender"] == "false" ? false : true,
                Adres = frm["address"],
                DepartmanID = int.Parse(frm["departmentId"]),
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

            ViewBag.DepartmanListesi = departmanConcrete._departmanRepository.GetAll();
            ViewBag.CalisanListesi = calisanConcrete._calisanRepository.GetEntity().Where(x => x.CalisanID != id).ToList();

            return View(calisanConcrete._calisanRepository.GetById(id));
        }
        [HttpPost]
        public ActionResult CalisanDuzenle(int id, FormCollection frm)
        {
            calisanConcrete = new CalisanConcrete();
            calisanDetayConcrete = new CalisanDetayConcrete();
            var calisanId = frm["CalisanID"].Split(',');

            var calisan = calisanConcrete._calisanRepository.GetById(int.Parse(calisanId[0]));

            calisan.CalisanAdi = frm["CalisanAdi"];
            calisan.CalisanSoyadi = frm["CalisanSoyadi"];
            calisan.Telefon = frm["Telefon"];
            if (frm["UstCalisanID"] != "")
                calisan.UstCalisanID = int.Parse(calisanId[1]);


            var calisanDetay = calisanDetayConcrete._calisanDetayRepository.GetById(calisan.CalisanID);
            if (calisanDetay == null)
                calisanDetay = new CalisanDetay();
            calisanDetay.Cinsiyet = frm["CalisanDetay.Cinsiyet"] == "false" ? false : true;
            calisanDetay.Adres = frm["CalisanDetay.Adres"];
            calisanDetay.DepartmanID = int.Parse(frm["CalisanDetay.DepartmanID"]);

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