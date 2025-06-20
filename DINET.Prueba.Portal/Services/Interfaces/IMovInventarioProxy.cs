using DINET.Prueba.Models.Request.Inventario;
using DINET.Prueba.Models.Response.Inventario;

namespace DINET.Prueba.Portal.Services.Interfaces
{
    /// <summary>
    /// IMovInventario Proxy
    /// </summary>
    public interface IMovInventarioProxy
    {
        /// <summary>
        /// IProxy: Consultar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<ICollection<MovInventarioDtoResponse>> Consultar(MovInventarioFiltroDtoRequest request);
    }
}