using DINET.Prueba.Models.Request.Inventario;
using DINET.Prueba.Models.Response.Base;
using DINET.Prueba.Models.Response.Inventario;
using DINET.Prueba.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DINET.Prueba.ApiRest.Controllers.Inventario
{
    /// <summary>
    /// Creador de API
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase
    {
        private readonly IMovInventarioService _service;

        /// <summary>
        /// Instanciar
        /// </summary>
        /// <param name="service"></param>
        public InventarioController(IMovInventarioService service)
        {
            _service = service;
        }

        /// <summary>
        /// ApiRest: Consultar
        /// </summary>
        /// <param name="request"></param>
        [HttpGet("Consultar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseGeneric<ICollection<MovInventarioDtoResponse>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseGeneric<ICollection<MovInventarioDtoResponse>>))]
        public async Task<IActionResult> Consultar([FromQuery] MovInventarioFiltroDtoRequest request)
        {
            var response = await _service.Consultar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: Insertar
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("Insertar")]
        public async Task<IActionResult> Insertar(MovInventarioDtoRequest request)
        {
            var response = await _service.Insertar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: Actualizar
        /// </summary>
        /// <param name="request"></param>
        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar(MovInventarioDtoRequest request)
        {
            var response = await _service.Actualizar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        /// <summary>
        /// ApiRest: Eliminar
        /// </summary>
        /// <param name="request"></param>
        [HttpDelete("Eliminar")]
        public async Task<IActionResult> Eliminar(MovInventarioDtoRequest request)
        {
            var response = await _service.Eliminar(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}