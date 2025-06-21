using DINET.Prueba.Models.Request.Acceso;
using DINET.Prueba.Models.Response.Acceso;
using DINET.Prueba.Models.Response.Base;

namespace DINET.Prueba.Services.Interfaces.Acceso
{
    /// <summary>
    /// IAcceso Service
    /// </summary>
    public interface IAccesoService
    {
        /// <summary>
        /// IService: Login
        /// </summary>
        /// <returns></returns>
        /// <param name="request"></param>
        Task<BaseResponseGeneric<UsuarioDtoResponse>> Login(UsuarioDtoRequest request);
    }
}