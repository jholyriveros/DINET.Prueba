// Mostrar modales
document.getElementById("btnNuevo").addEventListener("click", function () {
    $.ajax({
        url: urlCrearParcial,
        type: 'GET',
        success: function (html) {
            $("#modalInventario .modal-content").html(html);

            const $form = $("#modalInventario").find("form");

            // Resetear modo
            $form.data("modo", "insertar");

            // Habilitar campos clave
            const claves = [
                "COD_CIA", "COMPANIA_VENTA_3", "ALMACEN_VENTA",
                "TIPO_MOVIMIENTO", "TIPO_DOCUMENTO", "NRO_DOCUMENTO", "COD_ITEM_2"
            ];
            claves.forEach(campo => {
                $form.find(`[name='${campo}']`).prop("readonly", false);
            });

            // Re-parsear el validador
            if ($.validator && $.validator.unobtrusive) {
                $.validator.unobtrusive.parse($form);
            }

            // Mostrar modal
            const modal = new bootstrap.Modal(document.getElementById("modalInventario"));
            modal.show();
        },
        error: function () {
            mostrarModalMensaje("No se pudo abrir el formulario de nuevo.");
        }
    });
});

function mostrarModalMensaje(texto) {
    $("#modalMensajeBody").html(texto);
    var modal = new bootstrap.Modal(document.getElementById("modalMensaje"));
    modal.show();
}
// End Mostrar modales