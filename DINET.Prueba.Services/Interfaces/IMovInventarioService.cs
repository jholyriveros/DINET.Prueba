using DINET.Prueba.Models.Request.Inventario;
using DINET.Prueba.Models.Response.Base;
using DINET.Prueba.Models.Response.Inventario;

namespace DINET.Prueba.Services.Interfaces
{
    /// <summary>
    /// IMovInventario Service
    /// </summary>
    public interface IMovInventarioService
    {
        /// <summary>
        /// IService: Consultar
        /// </summary>
        /// <returns></returns>
        /// <param name="request"></param>
        Task<BaseResponseGeneric<ICollection<MovInventarioDtoResponse>>> Consultar(MovInventarioFiltroDtoRequest request);

        /// <summary>
        /// IService: Insertar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> Insertar(MovInventarioDtoRequest request);
    }
}