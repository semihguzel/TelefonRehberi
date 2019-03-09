﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.BLL.Repository.Concrete;

namespace TelefonRehberi.UI.Controllers
{
    public class YoneticiController : Controller
    {
        //View ve gerekli islemler yapilmadi.
        public ActionResult Index()
        {
            CalisanConcrete calisanConcrete = new CalisanConcrete();
            return View(calisanConcrete._calisanRepository.GetAll());
        }

    }
}