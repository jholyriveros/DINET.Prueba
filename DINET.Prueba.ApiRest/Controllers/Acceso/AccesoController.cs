using DINET.Prueba.Models.Request.Acceso;
using DINET.Prueba.Services.Interfaces.Acceso;
using Microsoft.AspNetCore.Mvc;

namespace DINET.Prueba.ApiRest.Controllers.Acceso
{
    /// <summary>
    /// Acceso Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AccesoController : ControllerBase
    {
        private readonly IAccesoService _service;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        public AccesoController(IAccesoService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UsuarioDtoRequest request)
        {
            var response = await _service.Login(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}