var obj;
var listaobj = new Array();
var comprobar;
var cantidadTotal = 0;
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
        method: "GET"
    }).done(function (data) {
        obj = new Object();
        $.each(listaobj, function (index, val) {
            if (val.id == data.data.id) {
                val.cantidad = parseInt(cantidad + 1);
                comprobar = true;    
            }
        });
        if (data.data == null)
            Alerta("error", "Error", "Este producto no existe")
        else if (data.data.status == false)
            Alerta("warning", "producto desactivado", "Este producto esta desactivado");
        else if (comprobar==true) {
            
        }
        else {
            obj.id = data.data.id;
            obj.codigoProducto = data.data.codigo;
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
    var cantidad = 1
    var descuento = parseFloat(1 - data.descuento)
    SubTotal = parseInt(data.precioVenta) * cantidad * descuento;
    var cadena;
    cadena = "<tr>"
    
    $.each(listaobj, function (index, val) {
        cadena = cadena + "<td>" + val.codigoProducto + "</td>";
        cadena = cadena + "<td>" + val.descripcion + "</td>";
        cadena = cadena + "<td>" + val.cantidad + "</td>";
        cadena = cadena + "<td>" + val.precioCompra + "</td>";
        cadena = cadena + "<td>" + val.subTotal + "</td>";
        cadena = cadena + "<td style='width: 150px;'><a class ='elimina'><button class='btn btn-danger' type='button'><span class='fa fa-remove'></span></button></a></td>";
        cantidadTotal = cantidadTotal + val.subTotal;
    });
    cadena = cadena + "</tr>"
    $("#CantidadTotal").val(cantidadTotal)
    $("#tablaventa").append(cadena);
    fn_dar_eliminar();
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


function CambiarCantidad(id,precioCompra) {
    (async () => {
        const { value: result } = await Swal.fire({
            input: 'number',
            inputLabel: 'Cantidad de piezas',
            inputPlaceholder: 'Cantidad'
        })
        if (result) {
            var cantidad = result
            $.each(listaobj, function (index, val) {
                if (val.id == id) {
                    val.id = cantidad;
                    val.precioCompra = parseFloat(precioCompra * cantidad);
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