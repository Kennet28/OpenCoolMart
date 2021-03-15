var Token;

$(document).ready(function () {
    $.ajax({
        url: "/Home/AsyncToken",
        method: "GET"
    }).done(function (data) {
        Token = data;
    }).fail(function (jqXHR, textStatus, error) {
        alert("lo sentimos ha habido un error");
    });
})
var tecla_enter;
function press_Enter() {
    tecla_enter = event.keyCode;
    if (tecla_enter == 13) {

        var codigo = $("#codigoprod").val();
        if (codigo != null && codigo.length != 0) {
            $.ajax({
                url: "https://opencoolmart.somee.com/api/Producto/Prod/" + codigo,
                headers: {"Authorization":"Bearer "+Token},
                method: "GET"
            }).done(function (data) {
                if (data.data == null)
                    alert("Este producto no existe")
                else {
                    Buscar(data.data);
                }
            }).fail(function (jqXHR, textStatus, error) {
                alert("lo sentimos ha habido un error");
            });
        }
        else {
            $.ajax({
                url: "https://opencoolmart.somee.com/api/Producto",
                headers: { "Authorization": "Bearer " + Token },
                method: "GET"
            }).done(function (data) {
                if (data.data == null)
                    alert("No hay productos registrados")
                if (data.data != null)
                    Llenartabla(data.data)
            }).fail(function (jqXHR, textStatus, error) {
                alert("lo sentimos ha habido un error");
            });
        }

    }
}
document.addEventListener('keydown', press_Enter);

function Buscar(data) {
    $('#tablaproductos tbody tr').remove();
    var cadena;
    cadena = "<tr>"
    cadena = cadena + "<td>" + data.codigoProducto + "</td>";
    cadena = cadena + "<td>" + data.descripcion + "</td>";
    cadena = cadena + "<td>" + data.precioVenta + "</td>";
    cadena = cadena + "<td>" + data.marca + "</td>";
    cadena = cadena + "<td>" + data.clasificacion + "</td>";
    cadena = cadena + "<td>" + data.stock + "</td>";
    cadena = cadena + "<td>" +
        "<a href='/Producto/Details/" + data.id + "' class='view' title='Ver' data-toggle='tooltip'><i class='material-icons'>&#xE417;</i></a>" +
        "<a href='/Producto/Update/" + data.id + "' class='edit' title='Editar' data-toggle='tooltip'><i class='material-icons'>&#xE254;</i></a>"
        + "</td>";

    $("#tablaproductos").append(cadena);
}
function Llenartabla(data) {
    $('#tablaproductos tbody tr').remove();
    var cadena;
    $.each(data, function (index, obj) {
        cadena = "<tr>"
        cadena = cadena + "<td>" + obj.codigoProducto + "</td>";
        cadena = cadena + "<td>" + obj.descripcion + "</td>";
        cadena = cadena + "<td>" + obj.precioVenta + "</td>";
        cadena = cadena + "<td>" + obj.marca + "</td>";
        cadena = cadena + "<td>" + obj.clasificacion + "</td>";
        cadena = cadena + "<td>" + obj.stock + "</td>";
        cadena = cadena + "<td>" +
            "<a href='/Producto/Details/" + obj.id + "' class='view' title='Ver' data-toggle='tooltip'><i class='material-icons'>&#xE417;</i></a>" +
            "<a href='/Producto/Update/" + obj.id + "' class='edit' title='Editar' data-toggle='tooltip'><i class='material-icons'>&#xE254;</i></a>"
            + "</td>";

        $("#tablaproductos").append(cadena);
    });
}