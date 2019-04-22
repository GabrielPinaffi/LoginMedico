using LoginTeste.Models;
using LoginTeste.Utils;
using LoginTeste.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LoginTeste.Controllers
{
    public class PerfilController : Controller
    {
        private UsuariosContext db = new UsuariosContext();
        // GET: Perfil
        [Authorize]
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModel viewmodel)
        {
            if(!ModelState.IsValid)
                return View();
            var identity = User.Identity as ClaimsIdentity;
            var login = identity.Claims.FirstOrDefault(c => c.Type == "Login").Value;
            var usr = db.Usuarios.FirstOrDefault(u => u.login == login);
            if(Hash.GerarHash(viewmodel.SenhaAtual) != usr.senha)
            {
                ModelState.AddModelError("SenhaAtual", "Senha Incorreta");
                return View();
            }
            usr.senha = Hash.GerarHash(viewmodel.NovaSenha);
            db.Entry(usr).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Painel");
        }
    }
}