using DINET.Prueba.Entities.Acceso;
using DINET.Prueba.Entities.Base;
using DINET.Prueba.Repositories.Interfaces.Acceso;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DINET.Prueba.Repositories.Implementaciones.Acceso
{
    public class AccesoRepository : IAccesoRepository
    {
        private readonly string _connectionString;

        /// <summary>
        /// MovInventario Repository
        /// </summary>
        /// <param name="configuration"></param>
        public AccesoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DINETDatabase")!;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request"></param>
        public async Task<BaseResponse<Usuarios>> Login(UsuariosFiltro request)
        {
            var response = new BaseResponse<Usuarios>();
            Usuarios user = new Usuarios();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_Login", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", request.Usuario);
                    cmd.Parameters.AddWithValue("@Clave", request.Clave);

                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            user = new Usuarios
                            {
                                Codigo = Convert.ToInt32(reader["Codigo"]),
                                Mensaje = reader["Mensaje"]?.ToString() ?? "",
                                IdUsuario = reader["IdUsuario"] != DBNull.Value ? Convert.ToInt32(reader["IdUsuario"]) : (int?)null,
                                Nombre = reader["Nombre"]?.ToString(),
                                Usuario = reader["Usuario"]?.ToString()
                            };
                        }
                    }
                }

                response.Data = user;
                response.Success = true;
            }
            catch (Exception ex)
            {
                var errorMsg = $"Error: {ex.Message}";
                response.Success = false;
                response.ErrorMessage = errorMsg;

                Utilitarios.LogHelper.RegistrarLog(errorMsg);
            }

            return response;
        }
    }
}
