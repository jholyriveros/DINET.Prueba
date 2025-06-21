using DINET.Prueba.Models.Request.Acceso;
using DINET.Prueba.Models.Response.Acceso;
using DINET.Prueba.Models.Response.Base;
using DINET.Prueba.Portal.Services.Interfaces.Acceso;

namespace DINET.Prueba.Portal.Services.Implementaciones.Acceso
{
    public class AccesoProxy : RestBase, IAccesoProxy
    {
        private readonly IHttpContextAccessor? _httpContextAccessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="httpContextAccessor"></param>
        public AccesoProxy(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
            : base("api/Acceso", httpClient)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        /// <summary>
        /// Proxy: Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UsuarioDtoResponse> Login(UsuarioDtoRequest request)
        {
            try
            {
                var response = await HttpClient.PostAsJsonAsync($"{BaseUrl}/Login", request);

                var result = await response.Content
                    .ReadFromJsonAsync<BaseResponseGeneric<UsuarioDtoResponse>>();

                // Si el response HTTP fue error (400), pero contiene un mensaje útil, úsalo
                if (!response.IsSuccessStatusCode || result?.Success == false)
                {
                    var mensaje = result?.ErrorMessage ?? "Error desconocido al iniciar sesión.";
                    throw new InvalidOperationException(mensaje);
                }

                return result!.Data!;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error: " + ex.Message);
            }
        }
    }
}