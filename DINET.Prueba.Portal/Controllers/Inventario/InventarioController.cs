using DINET.Prueba.Models.Request.Inventario;
using DINET.Prueba.Models.Response.Inventario;
using DINET.Prueba.Portal.Services.Interfaces.Inventario;
using DINET.Prueba.ViewModels.Inventario;
using Microsoft.AspNetCore.Mvc;

namespace DINET.Prueba.Portal.Controllers.Inventario
{
    /// <summary>
    /// Inventario Controller
    /// </summary>
    public class InventarioController : Controller
    {
        #region [Campos privados (inyección de dependencias)]
        private readonly IMovInventarioProxy _proxy;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _enviroment;
        private readonly ILogger<InventarioController> _logger;
        private readonly IHttpContextAccessor? _httpContextAccessor;
        #endregion

        #region[Constructor (inyección de dependencias)]
        /// <summary>
        /// Instanciar
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        /// <param name="logger"></param>
        /// <param name="httpContextAccessor"></param>
        public InventarioController(IMovInventarioProxy proxy,
                                    IConfiguration configuration,
                                    IWebHostEnvironment env,
                                    ILogger<InventarioController> logger,
                                    IHttpContextAccessor httpContextAccessor)
        {
            _proxy = proxy;
            _configuration = configuration;
            _enviroment = env;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }
        #endregion

        /// <summary>
        /// Index
        /// </summary>
        [HttpGet]
        public IActionResult Index(InventarioViewModel model)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Usuario")))
            {
                return RedirectToAction("Index", "Acceso");
            }

            // Establecer fechas por defecto si no se enviaron en el filtro para mostrar en el view
            if (!model.Filtro.FechaInicio.HasValue || !model.Filtro.FechaFin.HasValue)
            {
                model.Filtro.FechaInicio = new DateTime(2025, 1, 1);
                model.Filtro.FechaFin = DateTime.Today;
            }

            // Valor minimo para evitar errores
            if (model.PaginaActual <= 0) model.PaginaActual = 1;
            if (model.RegistrosPorPagina <= 0) model.RegistrosPorPagina = 10;

            // Consultar datos del API
            var resultado = _proxy.Consultar(model.Filtro);
            resultado.Wait();

            var lista = resultado.Result ?? new List<MovInventarioDtoResponse>();
            model.TotalRegistros = lista.Count;

            // Calcular total de páginas
            model.TotalPaginas = (int)Math.Ceiling(lista.Count / (double)model.RegistrosPorPagina);

            // Obtener la página actual
            model.ListaInventario = lista
                .Skip((model.PaginaActual - 1) * model.RegistrosPorPagina)
                .Take(model.RegistrosPorPagina)
                .ToList();

            return View(model);
        }

        /// <summary>
        /// Crear Parcial
        /// </summary>
        public IActionResult CrearParcial()
        {
            return PartialView("_ModalInventarioPartial", new MovInventarioDtoRequest());
        }

        /// <summary>
        /// Insertar
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Insertar(MovInventarioDtoRequest model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_ModalInventarioPartial", model);
            }

            try
            {
                await _proxy.Insertar(model);
                return Json(new { success = true, message = "Registro guardado correctamente." });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return PartialView("_ModalInventarioPartial", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ObtenerPorId([FromBody] MovInventarioClaveDtoRequest request)
        {
            try
            {
                var data = await _proxy.ObtenerPorId(request);
                return Json(data);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Actualizar
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Actualizar(MovInventarioDtoRequest model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_ModalInventarioPartial", model);
            }

            try
            {
                await _proxy.Actualizar(model);
                return Json(new { success = true, message = "Registro actualizado correctamente." });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return PartialView("_ModalInventarioPartial", model);
            }
        }

        /// <summary>
        /// Eliminar
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Eliminar([FromBody] MovInventarioClaveDtoRequest request)
        {
            try
            {
                await _proxy.Eliminar(request);
                return Json(new { success = true, message = "Registro eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}