var obj;
var listaobj = new Array();
var comprobar;
var cantidadTotal;
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

$(document).on("dblclick", "#tablacompra tbody tr", function () {
    var codigoProducto = $(this).children().eq('0').text();
    var precioCompra = $(this).children().eq('3').text();
    CambiarCantidad(codigoProducto,precioCompra);
});

$(document).on("dblclick", "#tablaproductos tbody tr", function () {
    var codigoProducto = $(this).children().eq('0').text();
    buscarcodigoProducto(codigoProducto);
});

$(document).on("dblclick", "#tablaproveedores tbody tr", function () {
    var id = $(this).children().eq('0').text();
    var nombre = $(this).children().eq('1').text();
    $("#IdProveedor").val(id);
    $("#NombreProveedor").val(nombre);
    $("#Modal").modal('hide');//ocultamos el modal
    $('body').removeClass('modal-open');//eliminamos la clase del body para poder hacer scroll
    $('.modal-backdrop').remove();//eliminamos el backdrop del modal
});

function ModalProductos() {
    $.ajax({
        url: "https://localhost:44315/api/Producto",
        headers: { "Authorization": "Bearer " + Token },
        method: "GET"
    }).done(function (data) {
        LLenarTablaProductos(data.data);
    }).fail(function (jqXHR, textStatus, error) {
        Alerta("error", "Error", "lo sentimos ha habido un error");
    });
}

function LLenarTablaProductos(data) {
    $('#tablaproductos tbody tr').remove();
    $('#tablaproductos thead tr').remove();
    $('#tablaproveedores tbody tr').remove();
    $('#tablaproveedores thead tr').remove();
    $('#tablaproductos tbody tr').remove();
    var thead ="<thead><tr> <th>Codigo Producto</th> <th>Descripción</th> <th>Descuento</th> <th> Precio Compra</th> <th>Cantidad Actual</th> </tr></thead>"
    var tbody ="<tbody>";
    $.each(data, function (index, obj) {
        tbody = tbody+ "<tr>"
        tbody = tbody + "<td>" + obj.codigoProducto + "</td>";
        tbody = tbody + "<td>" + obj.descripcion + "</td>";
        tbody = tbody + "<td>" + obj.descuento + "</td>";
        tbody = tbody + "<td>" + obj.precioCompra + "</td>";
        tbody = tbody + "<td>" + obj.stock + "</td> </tr>";
    });
    tbody=tbody+"</tbody>"
    $("#tablaproductos").append(thead);
    $("#tablaproductos").append(tbody);
}

function ModalProveedores() {
    $.ajax({
        url: "https://localhost:44315/api/Proveedor",
        headers: { "Authorization": "Bearer " + Token },
        method: "GET"
    }).done(function (data) {
        LLenarTablaProveedor(data.data);
    }).fail(function (jqXHR, textStatus, error) {
        Alerta("error", "Error", "lo sentimos ha habido un error");
    });
}
function LLenarTablaProveedor(data) {
    $('#tablaproductos tbody tr').remove();
    $('#tablaproductos thead tr').remove();
    $('#tablaproveedores tbody tr').remove();
    $('#tablaproveedores thead tr').remove();
    $('#tablaproductos tbody tr').remove();
    var thead = "<thead><tr><th>#</th> <th>Nombre</th>  <th>Dirección</th> <th>Correo</th> </tr></thead>"
    var tbody = "<tbody>";
    $.each(data, function (index, obj) {
        tbody = tbody + "<tr>"
        tbody = tbody + "<td>" + obj.id + "</td>";
        tbody = tbody + "<td>" + obj.nombre + "</td>";
        tbody = tbody + "<td>" + obj.direccion + "</td>";
        tbody = tbody + "<td>" + obj.correo +"</td> </tr>";
    });
    tbody = tbody + "</tbody>"
    $("#tablaproveedores").append(thead);
    $("#tablaproveedores").append(tbody);
}

function buscarcodigoProducto(codigoProducto) {
    $.ajax({
        url: "https://localhost:44315/api/Producto/Prod/" + codigoProducto,
        headers: { "Authorization": "Bearer " + Token },
        method: "GET"
    }).done(function (data) {
        comprobar = false;
        obj = new Object();
        $.each(listaobj, function (index, val) {
            if (val.id == data.data.id) {
                val.cantidad = parseInt(val.cantidad + 1);
                val.subTotal = val.subTotal + data.data.precioCompra;
                comprobar = true;    
            }
        });
        if (data.data == null)
            Alerta("error", "Error", "Este producto no existe")
        else if (data.data.status == false)
            Alerta("warning", "producto desactivado", "Este producto esta desactivado");
        else if (comprobar==true) {
            LlenarTabla();
        }
        else {
            obj.id = data.data.id;
            obj.codigoProducto = data.data.codigoProducto;
            obj.descripcion = data.data.descripcion;
            obj.cantidad = 1;
            obj.precioCompra = data.data.precioCompra;
            obj.subTotal = parseFloat(obj.precioCompra * obj.cantidad);
            listaobj.push(obj);
            LlenarTabla();
        }
        $("#Modal").modal('hide');//ocultamos el modal
        $('body').removeClass('modal-open');//eliminamos la clase del body para poder hacer scroll
        $('.modal-backdrop').remove();//eliminamos el backdrop del modal
    }).fail(function (jqXHR, textStatus, error) {
        Alerta("error", "Error", "lo sentimos ha habido un error");
    });
}

function LlenarTabla() {
    $('#tablacompra tbody tr').remove();
    var cadena;
    cantidadTotal = 0;  
    $.each(listaobj, function (index, val) {
        cadena = cadena+ "<tr>" 
        cadena = cadena + "<td>" + val.codigoProducto + "</td>";
        cadena = cadena + "<td>" + val.descripcion + "</td>";
        cadena = cadena + "<td>" + val.cantidad + "</td>";
        cadena = cadena + "<td>" + val.precioCompra + "</td>";
        cadena = cadena + "<td>" + val.subTotal + "</td>";
        cadena = cadena + "<td style='width: 150px;'><a class ='elimina'><button class='btn btn-danger' type='button'><span class='fa fa-remove'></span></button></a></td>";
        cantidadTotal = cantidadTotal + val.subTotal;
        cadena = cadena + "</tr>"
    });
    
    $("#CantidadTotal").val(cantidadTotal)
    $("#tablacompra").append(cadena);
    fn_dar_eliminar();
}

function CambiarCantidad(codigoProducto,precioCompra) {
    (async () => {
        const { value: result } = await Swal.fire({
            input: 'number',
            inputLabel: 'Cantidad de piezas',
            inputPlaceholder: 'Cantidad'
        })
        if (result) {
            var cantidad = parseInt(result)
            $.each(listaobj, function (index, val) {
                if (val.codigoProducto == codigoProducto) {
                    val.cantidad = cantidad;
                    val.subTotal = parseFloat(precioCompra * cantidad);
                    LlenarTabla();
                }
            });               
        }
    })()
}

function fn_dar_eliminar() {
    $("a.elimina").click(function () {
        valorindex = $(this).parents("tr").index()
        $(this).parents("tr").fadeOut("normal", function () {
            listaobj.splice(parseInt(valorindex), 1);
            LlenarTabla();
        });
    });
}

function RealizarCompra() {
    var EmpleadoId = $("#Empleado").val();
    var ProveedorId = $("#IdProveedor").val();
    var enviar = "{ProveedorId:" + ProveedorId + ",EmpleadoId:" + EmpleadoId + ",PrecioTotal:" + cantidadTotal;

    $.each(listaobj, function (index, val) {
        if (index == 0) {
            enviar += ",CompraProducto:[{ProductoId:" + val.id +
                ",CantidadProducto:" + val.cantidad +
                ",TotalPorProducto:" + val.cantidadTotal + "}"
        }
        else {
            enviar += ",{ProductoId:" + val.id +
                ",CantidadProducto:" + val.cantidad +
                ",TotalPorProducto:" + val.cantidadTotal + "}"
        }
    });
    enviar += "]}";

    var json = eval("(" + enviar + ')');
    $.ajax({
        url: "https://localhost:44315/api/Compra/",
        headers: { "Authorization": "Bearer " + Token },
        data: JSON.stringify(json),
        type: "POST",
        //async: false,//this makes the ajax-call blocking
        contentType: 'application/json;charset=UTF-8',
        dataType: 'json'
    }).done(function (data) {
        Alerta("success", "La venta se ha realizado con exito","Felicidades");
        Limpiar();
    }).fail(function (jqXHR, textStatus, error) {
        Alerta("error", "Error", "Ha ocurrido un error");
    });;
    /*if (parseFloat(efectivo) >= parseFloat(valorcompra)) {
    }
    else {
        Alerta("warning", "Dinero infuficiente", "El dinero pagado es menor al valor de la compra");
    }*/
}

function Alerta(icono, titulo, texto) {
    Swal.fire({
        position: 'Center',
        icon: icono,
        title: titulo,
        text: texto,
        //showConfirmButton: false,
    })
}