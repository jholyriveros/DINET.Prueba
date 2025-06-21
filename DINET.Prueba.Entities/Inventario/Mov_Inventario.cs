namespace DINET.Prueba.Entities.Inventario
{
    /// <summary>
    /// Entidad que representa un movimiento de inventario.
    /// </summary>
    public class Mov_Inventario
    {
        /// <summary>
        /// Código compañía
        /// </summary>
        public string COD_CIA { get; set; } = default!;

        /// <summary>
        /// Compañía venta 3
        /// </summary>
        public string COMPANIA_VENTA_3 { get; set; } = default!;

        /// <summary>
        /// Almacén venta
        /// </summary>
        public string ALMACEN_VENTA { get; set; } = default!;

        /// <summary>
        /// Tipo movimiento (IN, OU, etc.)
        /// </summary>
        public string TIPO_MOVIMIENTO { get; set; } = default!;

        /// <summary>
        /// Tipo documento (FV, etc.)
        /// </summary>
        public string TIPO_DOCUMENTO { get; set; } = default!;

        /// <summary>
        /// Número documento
        /// </summary>
        public string NRO_DOCUMENTO { get; set; } = default!;

        /// <summary>
        /// Código ítem
        /// </summary>
        public string COD_ITEM_2 { get; set; } = default!;

        /// <summary>
        /// Nombre proveedor
        /// </summary>
        public string? PROVEEDOR { get; set; }

        /// <summary>
        /// Almacén destino (si aplica)
        /// </summary>
        public string? ALMACEN_DESTINO { get; set; }

        /// <summary>
        /// Cantidad
        /// </summary>
        public int? CANTIDAD { get; set; }

        /// <summary>
        /// Documento referencia 1
        /// </summary>
        public string? DOC_REF_1 { get; set; }

        /// <summary>
        /// Documento referencia 2
        /// </summary>
        public string? DOC_REF_2 { get; set; }

        /// <summary>
        /// Documento referencia 3
        /// </summary>
        public string? DOC_REF_3 { get; set; }

        /// <summary>
        /// Documento referencia 4
        /// </summary>
        public string? DOC_REF_4 { get; set; }

        /// <summary>
        /// Documento referencia 5
        /// </summary>
        public string? DOC_REF_5 { get; set; }

        /// <summary>
        /// Fecha transacción
        /// </summary>
        public DateTime? FECHA_TRANSACCION { get; set; }
    }

    /// <summary>
    /// Entidad filtro para consultar movimientos de inventario
    /// </summary>
    public class Mov_InventarioFiltro
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
    }
}