using LoginTeste.Models;
using LoginTeste.ViewModels;
using LoginTeste.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Security.Claims;

namespace LoginTeste.Controllers
{
    public class AutenticacaoController : Controller
    {
        private UsuariosContext db = new UsuariosContext();
        // GET: Autenticacao
        public ActionResult Index()
        {
            var usrs = db.Usuarios.ToList();
            return View(usrs);
        }
        // GET: Autenticacao
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            
            if (db.Usuarios.Count(u=>u.login == viewModel.login) > 0)
            {
                ModelState.AddModelError("Login", "Esse login ja esta em uso");
                return View(viewModel);
            }

            Usuario usr = new Usuario
            {
                nome = viewModel.Nome,
                login = viewModel.login,
                senha = Hash.GerarHash(viewModel.senha)
            };

            db.Usuarios.Add(usr);
            db.SaveChanges();
            //TempData["Mensagem"] = "Cadastro realizade com sucesso";
            return RedirectToAction("Index","Home");
        }
        
        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Usuario u= db.Usuarios.Find(id);

            if (u == null)
                return HttpNotFound();
            return View(u);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Usuario u = db.Usuarios.Find(id);
            db.Usuarios.Remove(u);
            db.SaveChanges();
            return RedirectToAction("Index", "Autenticacao");
        }

        public ActionResult Login(string ReturnUrl)
        {
            var viewmodel = new LoginViewModels
            {
                UrlRetorno = ReturnUrl
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModels viewmodel)
        {
            if (!ModelState.IsValid)
                return View(viewmodel);

            Usuario usr = db.Usuarios.FirstOrDefault(u => u.login == viewmodel.login);

            if (usr == null )
            {
                ModelState.AddModelError("Senha", "Login ou senha esta errado, Falhou na sua única missão, lixo");
                return View(viewmodel);
            }

            if (usr.senha != Hash.GerarHash(viewmodel.Senha))
            {
                ModelState.AddModelError("Senha", "Login ou senha esta errado, Falhou na sua única missão, lixo");
                return View(viewmodel);
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usr.nome),
                new Claim("Login", usr.login)
            },"ApplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);
            if(!String.IsNullOrWhiteSpace(viewmodel.UrlRetorno) || Url.IsLocalUrl(viewmodel.UrlRetorno))
                return Redirect(viewmodel.UrlRetorno);
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout(LoginViewModels viewmodel)
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Login");
        }

    }
}