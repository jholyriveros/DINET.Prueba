﻿using DINET.Prueba.Models.Response.Base;

namespace DINET.Prueba.Models.Response.Inventario
{
    /// <summary>
    /// MovInventario Dto Response
    /// </summary>
    public class MovInventarioDtoResponse
    {
        /// <summary>
        /// Código de compañía
        /// </summary>
        public string COD_CIA { get; set; } = default!;

        /// <summary>
        /// Compañía de venta 3
        /// </summary>
        public string COMPANIA_VENTA_3 { get; set; } = default!;

        /// <summary>
        /// Almacén de venta
        /// </summary>
        public string ALMACEN_VENTA { get; set; } = default!;

        /// <summary>
        /// Tipo de movimiento (IN, OU, etc.)
        /// </summary>
        public string TIPO_MOVIMIENTO { get; set; } = default!;

        /// <summary>
        /// Tipo de documento (FV, etc.)
        /// </summary>
        public string TIPO_DOCUMENTO { get; set; } = default!;

        /// <summary>
        /// Número de documento
        /// </summary>
        public string NRO_DOCUMENTO { get; set; } = default!;

        /// <summary>
        /// Código del ítem
        /// </summary>
        public string COD_ITEM_2 { get; set; } = default!;

        /// <summary>
        /// Nombre del proveedor
        /// </summary>
        public string? PROVEEDOR { get; set; }

        /// <summary>
        /// Almacén de destino (si aplica)
        /// </summary>
        public string? ALMACEN_DESTINO { get; set; }

        /// <summary>
        /// Cantidad
        /// </summary>
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
        public DateTime? FECHA_TRANSACCION { get; set; }
    }
}