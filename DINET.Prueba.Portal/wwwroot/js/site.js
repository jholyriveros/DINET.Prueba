// Mostrar modales
document.getElementById("btnNuevo").addEventListener("click", function () {
    const form = document.getElementById("formInventario");

    // 1. Limpiar campos
    form.reset();

    // 2. Limpiar errores visuales
    $(form).find(".input-validation-error").removeClass("input-validation-error");

    // 3. Limpiar mensajes de error visibles (los internos también)
    $(form).find("span.field-validation-error")
        .removeClass("field-validation-error")
        .addClass("field-validation-valid")
        .text(""); // limpia el texto del span principal

    // 4. Limpia todos los <span id="XYZ-error"> que tengan texto residual
    $(form).find("span[id$='-error']").text("");

    // 4. Resetear el validador unobtrusive
    if ($.validator && $.validator.unobtrusive) {
        $.validator.unobtrusive.parse(form);
        $(form).validate().resetForm();
    }

    // 5. Mostrar modal
    var modal = new bootstrap.Modal(document.getElementById("modalInventario"));
    modal.show();
});

function mostrarModalMensaje(texto) {
    $("#modalMensajeBody").html(texto);
    var modal = new bootstrap.Modal(document.getElementById("modalMensaje"));
    modal.show();
}
// End Mostrar modales