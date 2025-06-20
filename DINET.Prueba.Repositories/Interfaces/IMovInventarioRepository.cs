using DINET.Prueba.Entities;
using DINET.Prueba.Entities.Base;

namespace DINET.Prueba.Repositories.Interfaces
{
    /// <summary>
    /// Interfaz para el repositorio de movimientos de inventario
    /// </summary>
    public interface IMovInventarioRepository
    {
        /// <summary>
        /// Consultar registros
        /// </summary>
        /// <param name="request">Filtros: FechaInicio, FechaFin, TipoMovimiento, NroDocumento</param>
        Task<BaseResponse<ICollection<Mov_Inventario>>> Consultar(Mov_InventarioFiltro request);

        /// <summary>
        /// Insertar
        /// </summary>
        /// <param name="request">
        Task<BaseResponse> Insertar(Mov_Inventario request);

        /// <summary>
        /// Actualizar
        /// </summary>
        /// <param name="request">
        Task<BaseResponse> Actualizar(Mov_Inventario request);

        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="request">
        Task<BaseResponse> Eliminar(Mov_Inventario request);
    }
}