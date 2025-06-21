namespace DINET.Prueba.Entities.Acceso
{
    /// <summary>
    /// Entidad que representa un usuario del sistema
    /// </summary>
    public class Usuarios
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

    public class UsuariosFiltro
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