using DINET.Prueba.Models.Request.Inventario;
using DINET.Prueba.Models.Response.Inventario;

namespace DINET.Prueba.ViewModels.Inventario
{
    /// <summary>
    /// Inventario ViewModel
    /// </summary>
    public class InventarioViewModel
    {
        /// <summary>
        /// MovInventario Filtro Dto Request
        /// </summary>
        public MovInventarioFiltroDtoRequest Filtro { get; set; } = new();

        /// <summary>
        /// Lista Inventario
        /// </summary>
        public ICollection<MovInventarioDtoResponse> ListaInventario { get; set; } = new List<MovInventarioDtoResponse>();

        /// <summary>
        /// Total de registros
        /// </summary>
        public int TotalRegistros { get; set; }

        /// <summary>
        /// Paginación
        /// </summary>
        public int PaginaActual { get; set; } = 1;
        public int TotalPaginas { get; set; }
        public int RegistrosPorPagina { get; set; } = 10;
    }
}