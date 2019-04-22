using LoginTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginTeste.Controllers
{
    public class EstadoController : Controller
    {
        private UsuariosContext db = new UsuariosContext();
        // GET: Estado
        public ActionResult Index()
        {
            var estados = db.Estados.ToList();
            return View(estados);
        }

        public ActionResult Create()
        {
            ViewBag.PaisId = new SelectList(db.Paises, "PaisId", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Estado viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.PaisId = new SelectList(db.Paises, "PaisId", "Nome");
                return View(viewModel);
            }

            if (db.Estados.Count(u => u.Nome == viewModel.Nome) > 0)
            {
                ModelState.AddModelError("Nome", "Esse nome de País já esta em uso");
                ViewBag.PaisId = new SelectList(db.Paises, "PaisId", "Nome");
                return View(viewModel);
            }

            db.Estados.Add(viewModel);
            db.SaveChanges();
            TempData["Mensagem"] = "Cadastro realizade com sucesso";
            ViewBag.PaisId = new SelectList(db.Paises, "PaisId", "Nome");
            return View();
        }
    }
}