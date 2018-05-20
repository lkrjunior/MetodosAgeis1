using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VagasShow.Reposistory;

namespace VagasShow.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(Memoria.GetVagas());
        }

        [HttpPost]
        public ActionResult Index(string pesquisa)
        {
            return View(Memoria.GetVagas(pesquisa));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Create.";

            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(VagasShow.Models.Vaga vaga)
        {
            ViewBag.Message = "Salva os dados da vaga.";

            vaga.PreencheIdData();
            Memoria.Add(vaga);

            return RedirectToAction("Index");
        }
    }
}