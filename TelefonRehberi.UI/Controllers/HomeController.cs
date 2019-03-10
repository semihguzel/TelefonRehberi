using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.BLL.Repository.Concrete;

namespace TelefonRehberi.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CalisanConcrete calisanConcrete = new CalisanConcrete();

            if (Session["KullaniciAdi"] == null)
            {
                return View(calisanConcrete._calisanRepository.GetAll());
            }
            else
            {
                return RedirectToAction("Index", "Yonetici");
            }
        }
    }
}