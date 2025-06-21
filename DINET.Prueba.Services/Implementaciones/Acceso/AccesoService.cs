using AutoMapper;
using DINET.Prueba.Entities.Acceso;
using DINET.Prueba.Models.Request.Acceso;
using DINET.Prueba.Models.Response.Acceso;
using DINET.Prueba.Models.Response.Base;
using DINET.Prueba.Repositories.Interfaces.Acceso;
using DINET.Prueba.Services.Interfaces.Acceso;

namespace DINET.Prueba.Services.Implementaciones.Acceso
{
    /// <summary>
    /// Acceso Service
    /// </summary>
    public class AccesoService : IAccesoService
    {
        private readonly IMapper _mapper;
        private readonly IAccesoRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        public AccesoService(IMapper mapper, IAccesoRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Service: Login
        /// </summary>
        /// <returns></returns>
        /// <param name="request"></param>
        public async Task<BaseResponseGeneric<UsuarioDtoResponse>> Login(UsuarioDtoRequest request)
        {
            var response = new BaseResponseGeneric<UsuarioDtoResponse>();

            try
            {
                var repositoryResponse = await _repository.Login(new UsuariosFiltro
                {
                    Usuario = request.Usuario,
                    Clave = request.Clave
                });

                if (repositoryResponse.Success)
                {
                    if (repositoryResponse.Data?.Codigo == 0)
                    {
                        response.Success = false;
                        response.ErrorMessage = repositoryResponse.Data?.Mensaje;
                    }
                    else
                    {
                        response.Data = _mapper.Map<UsuarioDtoResponse>(repositoryResponse.Data);
                        response.Success = true;
                    }   
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
    }
}