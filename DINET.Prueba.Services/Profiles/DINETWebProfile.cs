using DINET.Prueba.Models.Request.Inventario;
using DINET.Prueba.Models.Response.Inventario;
using AutoMapper;
using DINET.Prueba.Entities.Inventario;
using DINET.Prueba.Models.Request.Acceso;
using DINET.Prueba.Entities.Acceso;
using DINET.Prueba.Models.Response.Acceso;

namespace DINET.Prueba.Services.Profiles
{
    /// <summary>
    /// DINET Web Profile
    /// </summary>
    public class DINETWebProfile : Profile
    {
        /// <summary>
        /// Creador de AutoMapper - Map
        /// </summary>
        public DINETWebProfile() 
        {
            #region[Inventario]
            CreateMap<MovInventarioDtoRequest, Mov_Inventario>();
            CreateMap<MovInventarioFiltroDtoRequest, Mov_InventarioFiltro>();
            CreateMap<MovInventarioClaveDtoRequest, Mov_Inventario>();
            CreateMap<Mov_Inventario, MovInventarioDtoResponse>();
            #endregion

            #region[Acceso]
            CreateMap<UsuarioDtoRequest, UsuariosFiltro>();
            CreateMap<Usuarios, UsuarioDtoResponse>();
            #endregion
        }
    }
}