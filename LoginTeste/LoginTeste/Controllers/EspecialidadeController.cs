using LoginTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginTeste.Controllers
{
    public class EspecialidadeController : Controller
    {
        private UsuariosContext db = new UsuariosContext();
        // GET: Especialidade
        public ActionResult Index()
        {
            var especialidades = db.Especialidades.ToList();
            return View(especialidades);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Especialidade viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            if (db.Especialidades.Count(u => u.Nome == viewModel.Nome) > 0)
            {
                ModelState.AddModelError("Nome", "Esse nome de Especialidade já esta em uso");
                return View(viewModel);
            }

            db.Especialidades.Add(viewModel);
            db.SaveChanges();
            TempData["Mensagem"] = "Cadastro realizade com sucesso";
            return View();
        }
    }
}