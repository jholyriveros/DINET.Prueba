﻿using DINET.Prueba.Models.Request.Inventario;
using DINET.Prueba.Models.Response.Inventario;

namespace DINET.Prueba.Portal.Services.Interfaces.Inventario
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
        Task<ICollection<MovInventarioDtoResponse>> Consultar(MovInventarioFiltroDtoRequest request);

        /// <summary>
        /// IProxy: Insertar
        /// </summary>
        /// <param name="request"></param>
        Task Insertar(MovInventarioDtoRequest request);

        /// <summary>
        /// IProxy: Obtener Por Id
        /// </summary>
        /// <param name="request"></param>
        Task<MovInventarioDtoResponse> ObtenerPorId(MovInventarioClaveDtoRequest request);

        /// <summary>
        /// IProxy: Actualizar
        /// </summary>
        /// <param name="request"></param>
        Task Actualizar(MovInventarioDtoRequest request);

        /// <summary>
        /// IProxy: Eliminar
        /// </summary>
        /// <param name="request"></param>
        Task Eliminar(MovInventarioClaveDtoRequest request);
    }
}