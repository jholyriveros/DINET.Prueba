using AutoMapper;
using DINET.Prueba.Entities;
using DINET.Prueba.Models.Request.Inventario;
using DINET.Prueba.Models.Response.Base;
using DINET.Prueba.Models.Response.Inventario;
using DINET.Prueba.Repositories.Interfaces;
using DINET.Prueba.Services.Interfaces;

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