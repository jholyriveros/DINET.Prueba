using DINET.Prueba.Entities;
using DINET.Prueba.Models.Request.Inventario;
using DINET.Prueba.Models.Response.Inventario;
using AutoMapper;

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
            CreateMap<MovInventarioDtoRequest, Mov_Inventario>();
            CreateMap<MovInventarioFiltroDtoRequest, Mov_InventarioFiltro>();
            CreateMap<MovInventarioClaveDtoRequest, Mov_Inventario>();
            CreateMap<Mov_Inventario, MovInventarioDtoResponse>();
        }
    }
}