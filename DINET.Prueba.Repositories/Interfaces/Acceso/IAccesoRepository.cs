using DINET.Prueba.Entities.Acceso;
using DINET.Prueba.Entities.Base;

namespace DINET.Prueba.Repositories.Interfaces.Acceso
{
    public interface IAccesoRepository
    {
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request">
        Task<BaseResponse<Usuarios>> Login(UsuariosFiltro request);
    }
}