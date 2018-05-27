using System.Web.Mvc;
using VagasShow.Business;

namespace VagasShow.Controllers
{
    public class HomeController : Controller
    {
        #region Http Methods
        [HttpPost]
        public ActionResult Index(string pesquisa)
        {
            return View(new VagaBusiness().GetVagas(pesquisa));
        }

        [HttpPost]
        public ActionResult Create(VagasShow.Models.Vaga vaga)
        {
            new VagaBusiness().Add(vaga);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Limpar()
        {
            new VagaBusiness().CleanVagas();
            return RedirectToAction("Index");
        }
        #endregion

        #region Methods
        public ActionResult Index()
        {
            return View(new VagaBusiness().GetVagas());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("Create");
        }
        #endregion
    }
}