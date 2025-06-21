// Mostrar modal mensaje
function mostrarModalMensaje(texto) {
    $("#modalMensajeBody").html(texto);
    var modal = new bootstrap.Modal(document.getElementById("modalMensaje"));
    modal.show();
}