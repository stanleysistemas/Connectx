using ConnectX.Domain.Interfaces.Domain;
using ConnectX.UI.Web.Util;
using ConnectX.UI.Web.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ConnectX.UI.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IServicoDeUsuarioDomain _servicoUsuarioDominio;

        public AccountController(IServicoDeUsuarioDomain servicoUsuarioDominio)
        {
            _servicoUsuarioDominio = servicoUsuarioDominio;
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var usuario = _servicoUsuarioDominio.LogaUsuario(viewModel.Email, viewModel.Password);
            if (usuario == null)
            {
                ModelState.AddModelError("", "Email ou Senha incorretos.");
                return View(viewModel);
            }

            SessionManager.UsuarioLogado = usuario;

            return RedirectToAction("Index", "Home");
        }


        //[HttpGet]
        //public ActionResult PerFilUsuario(Login viewModel)
        //{
        //    if (!ModelState.IsValid)
        //        return View(viewModel);

        //    var usuario = _servicoUsuarioDominio.LogaUsuario(viewModel.Email, viewModel.Password);
        //    if (usuario == null)
        //    {
        //        ModelState.AddModelError("", "Email ou Senha incorretos.");
        //        return View(viewModel);
        //    }

        //    SessionManager.UsuarioLogado = usuario;

        //    return RedirectToAction("Index", "Home");
        //}

        public ActionResult Logoff()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            var viewModel = new RegisterViewModel();
            viewModel.ComboPerfilUsuario = _servicoUsuarioDominio.RecuperaTodosPerfisAtivos().Select(x => new SelectListItem { Text = x.NomePerfil, Value =Convert.ToString(x.IdPerfilUsuario) }); ;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            viewModel.ComboPerfilUsuario = _servicoUsuarioDominio.RecuperaTodosPerfisAtivos().Select(x => new SelectListItem { Text = x.NomePerfil, Value = Convert.ToString(x.IdPerfilUsuario) }); ;

            var usuarioExistente =_servicoUsuarioDominio.RecuperaUsuarioPorEmail(viewModel.Email);
            if(usuarioExistente != null)
            {
                ModelState.AddModelError("", "Email está sendo utilizado.");
                return View(viewModel);
            }

            _servicoUsuarioDominio.CadastraUsuario(
                new Domain.Entities.Usuario()
                {
                    Nome = viewModel.Nome,
                    DataCadastro = DateTime.Now,
                    Email = viewModel.Email,
                    //  IdPerfilUsuario = viewModel.IdPerfilUsuario,
                    IdPerfilUsuario = 2,
                    Senha = viewModel.Senha,
                    SenhaKey = Functions.GetRandomString()
                });

            var usuario = _servicoUsuarioDominio.LogaUsuario(viewModel.Email, viewModel.Senha);
            if (usuario == null)
            {
                ModelState.AddModelError("", "Email ou Senha incorretos.");
                return View(viewModel);
            }

            SessionManager.UsuarioLogado = usuario;

            return RedirectToAction("Index", "Home");
        }
    }
}