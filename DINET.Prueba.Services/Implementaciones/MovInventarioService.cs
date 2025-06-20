using AutoMapper;
using DINET.Prueba.Entities;
using DINET.Prueba.Models.Request.Inventario;
using DINET.Prueba.Models.Response.Base;
using DINET.Prueba.Models.Response.Inventario;
using DINET.Prueba.Repositories.Interfaces;
using DINET.Prueba.Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DINET.Prueba.Services.Implementaciones
{
    /// <summary>
    /// MovInventario Service
    /// </summary>
    public class MovInventarioService : IMovInventarioService
    {
        private readonly IMapper _mapper;
        private readonly IMovInventarioRepository _repository;

        /// <summary>
        /// Instanciar
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        public MovInventarioService(IMapper mapper, IMovInventarioRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Service: Consultar
        /// </summary>
        /// <returns></returns>
        /// <param name="request"></param>
        public async Task<BaseResponseGeneric<ICollection<MovInventarioDtoResponse>>> Consultar(MovInventarioFiltroDtoRequest request)
        {
            var response = new BaseResponseGeneric<ICollection<MovInventarioDtoResponse>>();

            try
            {
                var repositoryResponse = await _repository.Consultar(new Mov_InventarioFiltro
                {
                    FechaInicio = request.FechaInicio,
                    FechaFin = request.FechaFin,
                    TipoMovimiento = request.TipoMovimiento,
                    NroDocumento = request.NroDocumento
                });

                if (repositoryResponse.Success)
                {
                    response.Data = repositoryResponse.Data?
                        .Select(x => _mapper.Map<MovInventarioDtoResponse>(x))
                        .ToList();

                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = $"Repository Error: {repositoryResponse.ErrorMessage}";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = $"Service Error: {ex.Message}";
            }

            return response;
        }

        /// <summary>
        /// Service: Insertar
        /// </summary>
        /// <param name="request"></param>
        public async Task<BaseResponse> Insertar(MovInventarioDtoRequest request)
        {
            var response = new BaseResponse();

            try
            {
                var repositoryResponse = await _repository.Insertar(_mapper.Map<Mov_Inventario>(request));

                if (repositoryResponse.Success)
                {
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = $"Repository Error: {repositoryResponse.ErrorMessage}";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = "Service Error: " + ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Service: Obtener por Id
        /// </summary>
        /// <returns></returns>
        /// <param name="request"></param>
        public async Task<BaseResponseGeneric<MovInventarioDtoResponse>> ObtenerPorId(MovInventarioClaveDtoRequest request)
        {
            var response = new BaseResponseGeneric<MovInventarioDtoResponse>();

            try
            {
                var repositoryResponse = await _repository.ObtenerPorId(new Mov_Inventario
                {
                    COD_CIA = request.COD_CIA,
                    COMPANIA_VENTA_3 = request.COMPANIA_VENTA_3,
                    ALMACEN_VENTA = request.ALMACEN_VENTA,
                    TIPO_MOVIMIENTO = request.TIPO_MOVIMIENTO,
                    TIPO_DOCUMENTO = request.TIPO_DOCUMENTO,
                    NRO_DOCUMENTO = request.NRO_DOCUMENTO,
                    COD_ITEM_2 = request.COD_ITEM_2
                });

                if (repositoryResponse.Success)
                {
                    response.Data = _mapper.Map<MovInventarioDtoResponse>(repositoryResponse.Data);
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = $"Repository Error: {repositoryResponse.ErrorMessage}";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = $"Service Error: {ex.Message}";
            }

            return response;
        }

        /// <summary>
        /// Service: Actualizar
        /// </summary>
        /// <param name="request"></param>
        public async Task<BaseResponse> Actualizar(MovInventarioDtoRequest request)
        {
            var response = new BaseResponse();

            try
            {
                var repositoryResponse = await _repository.Actualizar(_mapper.Map<Mov_Inventario>(request));

                if (repositoryResponse.Success)
                {
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = $"Repository Error: {repositoryResponse.ErrorMessage}";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = "Service Error: " + ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Service: Eliminar
        /// </summary>
        /// <param name="request"></param>
        public async Task<BaseResponse> Eliminar(MovInventarioDtoRequest request)
        {
            var response = new BaseResponse();

            try
            {
                var repositoryResponse = await _repository.Eliminar(_mapper.Map<Mov_Inventario>(request));

                if (repositoryResponse.Success)
                {
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.ErrorMessage = $"Repository Error: {repositoryResponse.ErrorMessage}";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = "Service Error: " + ex.Message;
            }

            return response;
        }
    }
}