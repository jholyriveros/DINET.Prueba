using DINET.Prueba.Models.Request.Acceso;
using DINET.Prueba.Portal.Services.Interfaces.Acceso;
using Microsoft.AspNetCore.Mvc;

namespace DINET.Prueba.Portal.Controllers.Acceso
{
    /// <summary>
    /// Acceso Controller
    /// </summary>
    public class AccesoController : Controller
    {
        private readonly IAccesoProxy _proxy;

        /// <summary>
        /// Constructor
        /// </summary>
        public AccesoController(IAccesoProxy proxy)
        {
            _proxy = proxy;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Acceso/Login.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioDtoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", request);
            }

            try
            {
                var usuario = await _proxy.Login(request);

                HttpContext.Session.SetString("Usuario", usuario.Usuario ?? "");
                HttpContext.Session.SetInt32("IdUsuario", usuario.IdUsuario ?? 0);
                HttpContext.Session.SetString("Nombre", usuario.Nombre ?? "");

                return Json(new { success = true });
            }
            catch (InvalidOperationException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Ocurrió un error al iniciar sesión." });
            }
        }
    }
}