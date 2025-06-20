using DINET.Prueba.Entities.Base;
using DINET.Prueba.Entities;
using DINET.Prueba.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DINET.Prueba.Repositories.Implementaciones
{
    public class MovInventarioRepository : IMovInventarioRepository
    {
        private readonly string _connectionString;

        /// <summary>
        /// MovInventario Repository
        /// </summary>
        /// <param name="configuration"></param>
        public MovInventarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DINETDatabase")!;
        }

        /// <summary>
        /// Consultar
        /// </summary>
        /// <param name="request"></param>
        public async Task<BaseResponse<ICollection<Mov_Inventario>>> Consultar(Mov_InventarioFiltro request)
        {
            var response = new BaseResponse<ICollection<Mov_Inventario>>();
            var lista = new List<Mov_Inventario>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_ConsultarInventario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaInicio", (object?)request.FechaInicio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaFin", (object?)request.FechaFin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TipoMovimiento", (object?)request.TipoMovimiento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NroDocumento", (object?)request.NroDocumento ?? DBNull.Value);

                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lista.Add(new Mov_Inventario
                            {
                                COD_CIA = reader["COD_CIA"].ToString() ?? "",
                                COMPANIA_VENTA_3 = reader["COMPANIA_VENTA_3"].ToString() ?? "",
                                ALMACEN_VENTA = reader["ALMACEN_VENTA"].ToString() ?? "",
                                TIPO_MOVIMIENTO = reader["TIPO_MOVIMIENTO"].ToString() ?? "",
                                TIPO_DOCUMENTO = reader["TIPO_DOCUMENTO"].ToString() ?? "",
                                NRO_DOCUMENTO = reader["NRO_DOCUMENTO"].ToString() ?? "",
                                COD_ITEM_2 = reader["COD_ITEM_2"].ToString() ?? "",
                                PROVEEDOR = reader["PROVEEDOR"]?.ToString(),
                                ALMACEN_DESTINO = reader["ALMACEN_DESTINO"]?.ToString(),
                                CANTIDAD = reader["CANTIDAD"] != DBNull.Value ? Convert.ToInt32(reader["CANTIDAD"]) : null,
                                DOC_REF_1 = reader["DOC_REF_1"]?.ToString(),
                                DOC_REF_2 = reader["DOC_REF_2"]?.ToString(),
                                DOC_REF_3 = reader["DOC_REF_3"]?.ToString(),
                                DOC_REF_4 = reader["DOC_REF_4"]?.ToString(),
                                DOC_REF_5 = reader["DOC_REF_5"]?.ToString(),
                                FECHA_TRANSACCION = reader["FECHA_TRANSACCION"] != DBNull.Value ? Convert.ToDateTime(reader["FECHA_TRANSACCION"]) : null
                            });
                        }
                    }
                }

                response.Data = lista;
                response.Success = true;
            }
            catch (Exception ex)
            {
                var errorMsg = $"Error al consultar: {ex.Message}";
                response.Success = false;
                response.ErrorMessage = errorMsg;

                Utilitarios.LogHelper.RegistrarLog(errorMsg);
            }

            return response;
        }

        /// <summary>
        /// Insertar
        /// </summary>
        /// <param name="request"></param>
        public async Task<BaseResponse> Insertar(Mov_Inventario request)
        {
            var response = new BaseResponse();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_InsertarInventario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_CIA", request.COD_CIA);
                    cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", request.COMPANIA_VENTA_3);
                    cmd.Parameters.AddWithValue("@ALMACEN_VENTA", request.ALMACEN_VENTA);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", request.TIPO_MOVIMIENTO);
                    cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", request.TIPO_DOCUMENTO);
                    cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", request.NRO_DOCUMENTO);
                    cmd.Parameters.AddWithValue("@COD_ITEM_2", request.COD_ITEM_2);
                    cmd.Parameters.AddWithValue("@PROVEEDOR", (object?)request.PROVEEDOR ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ALMACEN_DESTINO", (object?)request.ALMACEN_DESTINO ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CANTIDAD", (object?)request.CANTIDAD ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_1", (object?)request.DOC_REF_1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_2", (object?)request.DOC_REF_2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_3", (object?)request.DOC_REF_3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_4", (object?)request.DOC_REF_4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_5", (object?)request.DOC_REF_5 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FECHA_TRANSACCION", (object?)request.FECHA_TRANSACCION ?? DBNull.Value);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                var errorMsg = $"Error al insertar: {ex.Message}";
                response.Success = false;
                response.ErrorMessage = errorMsg;

                Utilitarios.LogHelper.RegistrarLog(errorMsg);
            }

            return response;
        }

        /// <summary>
        /// Actualizar
        /// </summary>
        /// <param name="request"></param>
        public async Task<BaseResponse> Actualizar(Mov_Inventario request)
        {
            var response = new BaseResponse();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarInventario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_CIA", request.COD_CIA);
                    cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", request.COMPANIA_VENTA_3);
                    cmd.Parameters.AddWithValue("@ALMACEN_VENTA", request.ALMACEN_VENTA);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", request.TIPO_MOVIMIENTO);
                    cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", request.TIPO_DOCUMENTO);
                    cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", request.NRO_DOCUMENTO);
                    cmd.Parameters.AddWithValue("@COD_ITEM_2", request.COD_ITEM_2);
                    cmd.Parameters.AddWithValue("@PROVEEDOR", (object?)request.PROVEEDOR ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ALMACEN_DESTINO", (object?)request.ALMACEN_DESTINO ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CANTIDAD", (object?)request.CANTIDAD ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_1", (object?)request.DOC_REF_1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_2", (object?)request.DOC_REF_2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_3", (object?)request.DOC_REF_3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_4", (object?)request.DOC_REF_4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_5", (object?)request.DOC_REF_5 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FECHA_TRANSACCION", (object?)request.FECHA_TRANSACCION ?? DBNull.Value);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                var errorMsg = $"Error al actualizar: {ex.Message}";
                response.Success = false;
                response.ErrorMessage = errorMsg;

                Utilitarios.LogHelper.RegistrarLog(errorMsg);
            }

            return response;
        }

        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="request"></param>
        public async Task<BaseResponse> Eliminar(Mov_Inventario request)
        {
            var response = new BaseResponse();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_EliminarInventario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_CIA", request.COD_CIA);
                    cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", request.COMPANIA_VENTA_3);
                    cmd.Parameters.AddWithValue("@ALMACEN_VENTA", request.ALMACEN_VENTA);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", request.TIPO_MOVIMIENTO);
                    cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", request.TIPO_DOCUMENTO);
                    cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", request.NRO_DOCUMENTO);
                    cmd.Parameters.AddWithValue("@COD_ITEM_2", request.COD_ITEM_2);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                var errorMsg = $"Error al eliminar: {ex.Message}";
                response.Success = false;
                response.ErrorMessage = errorMsg;

                Utilitarios.LogHelper.RegistrarLog(errorMsg);
            }

            return response;
        }
    }
}