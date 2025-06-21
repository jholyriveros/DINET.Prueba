namespace DINET.Prueba.Models.Response.Acceso
{
    /// <summary>
    /// Usuario Dto Response
    /// </summary>
    public class UsuarioDtoResponse
    {
        /// <summary>
        /// Id Usuario
        /// </summary>
        public int IdUsuario { get; set; } = default!;

        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; } = default!;

        /// <summary>
        /// Usuario
        /// </summary>
        public string Usuario { get; set; } = default!;

        /// <summary>
        /// Mensaje
        /// </summary>
        public string Mensaje { get; set; } = default!;

        /// <summary>
        /// Codigo
        /// </summary>
        public int Codigo { get; set; } = default!;
    }
}