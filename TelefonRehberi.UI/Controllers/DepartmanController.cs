using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.BLL.Repository.Concrete;
using TelefonRehberi.DATA.Entities;

namespace TelefonRehberi.UI.Controllers
{
    public class DepartmanController : Controller
    {
        DepartmanConcrete departmanConcrete;
        public ActionResult DepartmanIndex()
        {
            if (Session["KullaniciAdi"] != null)
            {
                departmanConcrete = new DepartmanConcrete();
                return View(departmanConcrete._departmanRepository.GetAll());
            }
            else
                return RedirectToAction("Giris", "Yonetici");
        }

        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(FormCollection frm)
        {
            //TODO: Aynı departman ismi varsa kayıt edilmediğine dair bilgi verilmeli...
            departmanConcrete = new DepartmanConcrete();

            Departman departman = departmanConcrete.GetByName(frm["name"]);
            if (departman == null)
            {
                departman = new Departman();
                departman.DepartmanAdi = frm["name"];
                departmanConcrete._departmanRepository.Insert(departman);
                departmanConcrete._departmanUnitOfWork.SaveChanges();
                departmanConcrete._departmanUnitOfWork.Dispose();
            }
            return RedirectToAction("DepartmanIndex");
        }

        public ActionResult DepartmanGuncelle(int id)
        {
            departmanConcrete = new DepartmanConcrete();

            return View(departmanConcrete._departmanRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult DepartmanGuncelle(FormCollection frm)
        {
            departmanConcrete = new DepartmanConcrete();

            Departman departman = departmanConcrete._departmanRepository.GetById(Convert.ToInt32(frm["DepartmanID"]));
            departman.DepartmanAdi = frm["DepartmanAdi"];

            departmanConcrete._departmanUnitOfWork.SaveChanges();
            departmanConcrete._departmanUnitOfWork.Dispose();

            return RedirectToAction("DepartmanIndex");
        }

        public ActionResult DepartmanSil(int id)
        {
            departmanConcrete = new DepartmanConcrete();

            departmanConcrete._departmanRepository.Delete(id);
            departmanConcrete._departmanUnitOfWork.SaveChanges();
            departmanConcrete._departmanUnitOfWork.Dispose();

            return RedirectToAction("DepartmanIndex");
        }
    }
}