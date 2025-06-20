﻿using DINET.Prueba.Helpers;
using DINET.Prueba.Models.Request.Inventario;
using DINET.Prueba.Models.Response.Base;
using DINET.Prueba.Models.Response.Inventario;
using DINET.Prueba.Portal.Services.Interfaces.Inventario;

namespace DINET.Prueba.Portal.Services.Implementaciones.Inventario
{
    public class MovInventarioProxy : RestBase, IMovInventarioProxy
    {
        private readonly IHttpContextAccessor? _httpContextAccessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="httpContextAccessor"></param>
        public MovInventarioProxy(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
            : base("api/Inventario", httpClient)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        /// <summary>
        /// Proxy: Consultar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ICollection<MovInventarioDtoResponse>> Consultar(MovInventarioFiltroDtoRequest request)
        {
            try
            {
                var queryParams = request.ToDictionary();
                var queryString = Serializacion.ToQueryString(queryParams!);
                if (queryString == "?") queryString = "";                

                var response = await HttpClient.GetAsync($"{BaseUrl}/Consultar{queryString}");
                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<ICollection<MovInventarioDtoResponse>>>();

                if (result!.Success == false)
                {
                    throw new InvalidOperationException(result.ErrorMessage);
                }

                return result.Data!;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        /// <summary>
        /// Proxy: Insertar
        /// </summary>
        /// <param name="request"></param>
        public async Task Insertar(MovInventarioDtoRequest request)
        {
            try
            {
                var response = await HttpClient.PostAsJsonAsync($"{BaseUrl}/Insertar", request);

                var result = await response.Content.ReadFromJsonAsync<BaseResponse>();

                if (response.IsSuccessStatusCode)
                {
                    if (result!.Success == false)
                        throw new InvalidOperationException(result.ErrorMessage);
                }
                else
                {
                    var mensaje = result?.ErrorMessage ?? "Error inesperado al insertar.";
                    throw new InvalidOperationException(mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        /// <summary>
        /// Proxy: Obtener Por Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<MovInventarioDtoResponse> ObtenerPorId(MovInventarioClaveDtoRequest request)
        {
            try
            {
                var response = await HttpClient.PostAsJsonAsync($"{BaseUrl}/ObtenerPorId", request);
                response.EnsureSuccessStatusCode();

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<MovInventarioDtoResponse>>();

                if (result!.Success == false)
                {
                    throw new InvalidOperationException(result.ErrorMessage);
                }

                return result.Data!;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        /// <summary>
        /// Proxy: Actualizar
        /// </summary>
        /// <param name="request"></param>
        public async Task Actualizar(MovInventarioDtoRequest request)
        {
            try
            {
                var response = await HttpClient.PutAsJsonAsync($"{BaseUrl}/Actualizar", request);
                if (response.IsSuccessStatusCode)
                {
                    var resultado = await response.Content.ReadFromJsonAsync<BaseResponse>();
                    if (resultado!.Success == false)
                        throw new InvalidOperationException(resultado.ErrorMessage);
                }
                else
                {
                    throw new InvalidOperationException(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        /// <summary>
        /// Proxy: Eliminar
        /// </summary>
        /// <param name="request"></param>
        public async Task Eliminar(MovInventarioClaveDtoRequest request)
        {
            try
            {
                var httpRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri($"{HttpClient.BaseAddress}{BaseUrl}/Eliminar"),
                    Content = JsonContent.Create(request)
                };

                var response = await HttpClient.SendAsync(httpRequest);

                if (response.IsSuccessStatusCode)
                {
                    var resultado = await response.Content.ReadFromJsonAsync<BaseResponse>();
                    if (resultado?.Success == false)
                        throw new InvalidOperationException(resultado.ErrorMessage);
                }
                else
                {
                    throw new InvalidOperationException(response.ReasonPhrase ?? "Error al eliminar.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al eliminar: " + ex.Message);
            }
        }
    }
}