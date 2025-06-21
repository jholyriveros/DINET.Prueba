using DINET.Prueba.Models.Request.Acceso;
using DINET.Prueba.Models.Response.Acceso;

namespace DINET.Prueba.Portal.Services.Interfaces.Acceso
{
    /// <summary>
    /// IAcceso Proxy
    /// </summary>
    public interface IAccesoProxy
    {
        /// <summary>
        /// IProxy: Login
        /// </summary>
        /// <param name="request"></param>
        Task<UsuarioDtoResponse> Login(UsuarioDtoRequest request);
    }
}