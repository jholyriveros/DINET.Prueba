// Mostrar modal nuevo
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


$(document).on("click", ".btn-editar", function () {
    const data = $(this).data("model");

    $.ajax({
        url: urlObtenerPorId,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: function (result) {
            if (!result) {
                mostrarModalMensaje("No se pudo obtener el registro.");
                return;
            }

            const datos = result;

            // Llenar campos
            for (const campo in datos) {
                const campoMayus = campo.toUpperCase();
                const $input = $("#formInventario").find(`[name='${campoMayus}']`);

                if ($input.length > 0) {
                    const tipo = $input.attr("type");
                    const valor = datos[campo];

                    if (tipo === "date" && valor) {
                        $input.val(valor.substring(0, 10));
                    } else {
                        $input.val(valor);
                    }
                } else {
                    console.warn(`No se encontró el campo '${campoMayus}' en el formulario.`);
                }
            }

            // Bloquear claves
            const claves = [
                "COD_CIA", "COMPANIA_VENTA_3", "ALMACEN_VENTA",
                "TIPO_MOVIMIENTO", "TIPO_DOCUMENTO", "NRO_DOCUMENTO", "COD_ITEM_2"
            ];
            claves.forEach(campo => {
                $("#formInventario").find(`[name='${campo}']`)
                    .prop("readonly", true)
                    .addClass("bg-light");
            });

            // Modo edición
            const $form = $("#formInventario");
            $form.data("modo", "editar");

            // Limpiar validaciones
            $form.find(".input-validation-error").removeClass("input-validation-error");
            $form.find("span.field-validation-error")
                .removeClass("field-validation-error")
                .addClass("field-validation-valid")
                .text("");
            $form.find("span[id$='-error']").text("");

            if ($.validator && $.validator.unobtrusive) {
                $.validator.unobtrusive.parse($form);
                $form.validate().resetForm();
            }

            // Mostrar modal
            const modal = new bootstrap.Modal(document.getElementById("modalInventario"));
            modal.show();
        },
        error: function () {
            mostrarModalMensaje("Ocurrió un error al obtener los datos del inventario.");
        }
    });
});