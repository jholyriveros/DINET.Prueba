namespace DINET.Prueba.Models.Request.Acceso
{
    /// <summary>
    /// Usuario Dto Request
    /// </summary>
    public class UsuarioDtoRequest
    {
        /// <summary>
        /// Usuario
        /// </summary>
        public string Usuario { get; set; } = default!;

        /// <summary>
        /// Clave
        /// </summary>
        public string Clave { get; set; } = default!;
    }
}