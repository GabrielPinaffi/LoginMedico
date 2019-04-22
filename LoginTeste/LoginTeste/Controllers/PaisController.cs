using LoginTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginTeste.Controllers
{
    public class PaisController : Controller
    {
        private UsuariosContext db = new UsuariosContext();
        // GET: Pais
        public ActionResult Index()
        {
            var paises = db.Paises.ToList();
            return View(paises);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pais viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            if (db.Paises.Count(u => u.Nome == viewModel.Nome) > 0)
            {
                ModelState.AddModelError("Nome", "Esse nome de País já esta em uso");
                return View(viewModel);
            }

            db.Paises.Add(viewModel);
            db.SaveChanges();
            TempData["Mensagem"] = "Cadastro realizade com sucesso";
            return View();
        }
    }
}