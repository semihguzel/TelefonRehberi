using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.BLL.Repository.Concrete;
using TelefonRehberi.DATA.Entities;

namespace TelefonRehberi.UI.Controllers
{
    public class YoneticiController : Controller
    {
        YoneticiConcrete yoneticiConcrete;
        public ActionResult Index()
        {
            if (Session["KullaniciAdi"] == null)
                return RedirectToAction("Giris", "Yonetici");
            else
            {
                CalisanConcrete calisanConcrete = new CalisanConcrete();

                return View(calisanConcrete._calisanRepository.GetAll());
            }
        }

        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(FormCollection frm)
        {
            string kullaniciAdi = frm["username"];
            string sifre = frm["password"];

            YoneticiConcrete yoneticiConcrete = new YoneticiConcrete();
            if (yoneticiConcrete.Login(kullaniciAdi, sifre))
            {
                Session["KullaniciAdi"] = kullaniciAdi;
                return RedirectToAction("Index", "Yonetici");
            }
            else
                return View();
        }

        public ActionResult Cikis()
        {
            Session["KullaniciAdi"] = null;
            return RedirectToAction("Index","Home");
        }

        public ActionResult YoneticiGuncelle(int id)
        {
            yoneticiConcrete = new YoneticiConcrete();

            return View(yoneticiConcrete._yoneticiRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult YoneticiGuncelle(FormCollection frm)
        {
            yoneticiConcrete = new YoneticiConcrete();
            Yonetici yonetici = yoneticiConcrete._yoneticiRepository.GetById(Convert.ToInt32(frm["YoneticiID"]));
            yonetici.KullaniciAdi = frm["KullaniciAdi"];
            yonetici.Sifre = frm["Sifre"];
            yonetici.AktifMi = true;

            yoneticiConcrete._yoneticiUnitOfWork.SaveChanges();
            yoneticiConcrete._yoneticiUnitOfWork.Dispose();
            Session["KullaniciAdi"] = null;

            return RedirectToAction("Giris", "Yonetici");
        }

    }
}