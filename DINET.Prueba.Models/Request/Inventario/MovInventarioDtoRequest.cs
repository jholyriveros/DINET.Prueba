using System.ComponentModel.DataAnnotations;

namespace DINET.Prueba.Models.Request.Inventario
{
    /// <summary>
    /// MovInventario Dto Request
    /// </summary>
    public class MovInventarioDtoRequest
    {
        /// <summary>
        /// Código de compañía
        /// </summary>
        [Required(ErrorMessage = "Cód. CIA es obligatorio")]
        public string COD_CIA { get; set; } = default!;

        /// <summary>
        /// Compañía de venta 3
        /// </summary>
        [Required(ErrorMessage = "Compañía venta es obligatorio")]
        public string COMPANIA_VENTA_3 { get; set; } = default!;

        /// <summary>
        /// Almacén de venta
        /// </summary>
        [Required(ErrorMessage = "Almacén venta es obligatorio")]
        public string ALMACEN_VENTA { get; set; } = default!;

        /// <summary>
        /// Tipo de movimiento (IN, OU, etc.)
        /// </summary>
        [Required(ErrorMessage = "Tipo movimiento es obligatorio")]
        public string TIPO_MOVIMIENTO { get; set; } = default!;

        /// <summary>
        /// Tipo de documento (FV, etc.)
        /// </summary>
        [Required(ErrorMessage = "Tipo documento es obligatorio")]
        public string TIPO_DOCUMENTO { get; set; } = default!;

        /// <summary>
        /// Número de documento
        /// </summary>
        [Required(ErrorMessage = "Nro. documento es obligatorio")]
        public string NRO_DOCUMENTO { get; set; } = default!;

        /// <summary>
        /// Código del ítem
        /// </summary>
        [Required(ErrorMessage = "Cod. Item 2 es obligatorio")]
        public string COD_ITEM_2 { get; set; } = default!;

        /// <summary>
        /// Nombre del proveedor
        /// </summary>
        [Required(ErrorMessage = "Proveedor es obligatorio")]
        public string? PROVEEDOR { get; set; }

        /// <summary>
        /// Almacén de destino (si aplica)
        /// </summary>
        [Required(ErrorMessage = "Almacén destino es obligatorio")]
        public string? ALMACEN_DESTINO { get; set; }

        /// <summary>
        /// Cantidad
        /// </summary>
        [Required(ErrorMessage = "Cantidad es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Cantidad debe ser mayor a cero")]
        public int? CANTIDAD { get; set; }

        /// <summary>
        /// Documento de referencia 1
        /// </summary>
        public string? DOC_REF_1 { get; set; }

        /// <summary>
        /// Documento de referencia 2
        /// </summary>
        public string? DOC_REF_2 { get; set; }

        /// <summary>
        /// Documento de referencia 3
        /// </summary>
        public string? DOC_REF_3 { get; set; }

        /// <summary>
        /// Documento de referencia 4
        /// </summary>
        public string? DOC_REF_4 { get; set; }

        /// <summary>
        /// Documento de referencia 5
        /// </summary>
        public string? DOC_REF_5 { get; set; }

        /// <summary>
        /// Fecha de transacción
        /// </summary>
        [Required(ErrorMessage = "Fecha transacción es obligatorio")]
        public DateTime? FECHA_TRANSACCION { get; set; } = DateTime.Now;
    }

    /// <summary>
    /// MovInventario Filtro Dto Request
    /// </summary>
    public class MovInventarioFiltroDtoRequest
    {
        /// <summary>
        /// Fecha Inicio
        /// </summary>
        public DateTime? FechaInicio { get; set; }

        /// <summary>
        /// Fecha Fin
        /// </summary>
        public DateTime? FechaFin { get; set; }

        /// <summary>
        /// Tipo Movimiento
        /// </summary>
        public string? TipoMovimiento { get; set; }

        /// <summary>
        /// Nro Documento
        /// </summary>
        public string? NroDocumento { get; set; }

        public Dictionary<string, string> ToDictionary()
        {
            var dict = new Dictionary<string, string>();

            if (FechaInicio.HasValue) dict["FechaInicio"] = FechaInicio.Value.ToString("yyyy-MM-dd");
            if (FechaFin.HasValue) dict["FechaFin"] = FechaFin.Value.ToString("yyyy-MM-dd");
            if (!string.IsNullOrEmpty(TipoMovimiento)) dict["TipoMovimiento"] = TipoMovimiento;
            if (!string.IsNullOrEmpty(NroDocumento)) dict["NroDocumento"] = NroDocumento;

            return dict;
        }
    }

    /// <summary>
    /// MovInventario Clave Dto Request
    /// </summary>
    public class MovInventarioClaveDtoRequest
    {
        /// <summary>
        /// COD_CIA
        /// </summary>
        [Required]
        public string COD_CIA { get; set; } = default!;

        /// <summary>
        /// COMPANIA_VENTA_3
        /// </summary>
        [Required]
        public string COMPANIA_VENTA_3 { get; set; } = default!;

        /// <summary>
        /// ALMACEN_VENTA
        /// </summary>
        [Required]
        public string ALMACEN_VENTA { get; set; } = default!;

        /// <summary>
        /// TIPO_MOVIMIENTO
        /// </summary>
        [Required]
        public string TIPO_MOVIMIENTO { get; set; } = default!;

        /// <summary>
        /// TIPO_DOCUMENTO
        /// </summary>
        [Required]
        public string TIPO_DOCUMENTO { get; set; } = default!;

        /// <summary>
        /// NRO_DOCUMENTO
        /// </summary>
        [Required]
        public string NRO_DOCUMENTO { get; set; } = default!;

        /// <summary>
        /// COD_ITEM_2
        /// </summary>
        [Required]
        public string COD_ITEM_2 { get; set; } = default!;
    }
}