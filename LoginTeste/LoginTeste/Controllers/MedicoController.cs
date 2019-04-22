using LoginTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginTeste.Controllers
{
    public class MedicoController : Controller
    {
        private UsuariosContext db = new UsuariosContext();
        // GET: Medico
        public ActionResult Index()
        {
            var med = db.Medicos.ToList();
            return View(med);
        }

        public ActionResult Create()
        {
            ViewBag.CidadeId = new SelectList(db.Cidades, "CidadeId", "Nome");
            ViewBag.EspecialidadeId = new SelectList(db.Especialidades, "EspecialidadeId", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Medico viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CidadeId = new SelectList(db.Cidades, "CidadeId", "Nome");
                ViewBag.EspecialidadeId = new SelectList(db.Especialidades, "EspecialidadeId", "Nome");
                return View(viewModel);
            }

            /*
            if (db.Medicos.Count(u => u.Nome == viewModel.Nome) > 0)
            {
                ModelState.AddModelError("Nome", "Esse nome de País já esta em uso");
                ViewBag.PaisId = new SelectList(db.Paises, "PaisId", "Nome");
                return View(viewModel);
            }*/

            db.Medicos.Add(viewModel);
            db.SaveChanges();
            TempData["Mensagem"] = "Cadastro realizade com sucesso";
            ViewBag.CidadeId = new SelectList(db.Cidades, "CidadeId", "Nome");
            ViewBag.EspecialidadeId = new SelectList(db.Especialidades, "EspecialidadeId", "Nome");
            return View();
        }
    }
}