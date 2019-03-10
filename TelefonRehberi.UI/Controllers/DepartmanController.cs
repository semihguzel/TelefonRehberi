using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.BLL.Repository.Concrete;

namespace TelefonRehberi.UI.Controllers
{
    public class DepartmanController : Controller
    {
        public ActionResult Departman()
        {
            DepartmanConcrete departmanConcrete = new DepartmanConcrete();
            return View(departmanConcrete._departmanRepository.GetAll());
        }
    }
}