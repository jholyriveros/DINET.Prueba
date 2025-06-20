using DINET.Prueba.Portal.Services.Interfaces;
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

        public IActionResult Index(InventarioViewModel model)
        {
            if (!model.Filtro.FechaInicio.HasValue && !model.Filtro.FechaFin.HasValue)
            {
                model.Filtro.FechaInicio = new DateTime(2025, 1, 1);
                model.Filtro.FechaFin = new DateTime(2025, 6, 30);
            }

            var resultado = _proxy.Consultar(model.Filtro);
            resultado.Wait();

            var lista = resultado.Result;

            model.TotalPaginas = (int)Math.Ceiling(lista.Count / (double)model.RegistrosPorPagina);

            model.ListaInventario = lista
                .Skip((model.PaginaActual - 1) * model.RegistrosPorPagina)
                .Take(model.RegistrosPorPagina)
                .ToList();

            return View(model);
        }
    }
}