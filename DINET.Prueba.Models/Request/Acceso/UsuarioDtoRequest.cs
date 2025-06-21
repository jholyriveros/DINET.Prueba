using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string Usuario { get; set; } = default!;

        /// <summary>
        /// Clave
        /// </summary>
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Clave { get; set; } = default!;
    }
}