using LoginTeste.Models;
using LoginTeste.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginTeste.Controllers
{
    public class CidadeController : Controller
    {
        private UsuariosContext db = new UsuariosContext();
        // GET: Cidade
        public ActionResult Index()
        {
            var city = db.Cidades.ToList();
            return View(city);
        }
        
        public ActionResult Create()
        {
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cidade viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Nome");
                return View(viewModel);
            }

            if (db.Cidades.Count(u => u.Nome == viewModel.Nome) > 0)
            {
                ModelState.AddModelError("Nome", "Esse nome de cidade já esta em uso");
                ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Nome");
                return View(viewModel);
            }
            
            db.Cidades.Add(viewModel);
            db.SaveChanges();
            TempData["Mensagem"] = "Cadastro realizade com sucesso";
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Nome");
            return View();
        }
    }
}