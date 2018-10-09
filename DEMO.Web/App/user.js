const $_GET = 'GET';
const $_POST = 'POST';
const controlador = siteRoot + 'Configuration/';
var $table = $("#tblRegistros");

$(function () {
    $('#dtFechaIFiltro').datetimepicker({
        format: 'DD/MM/YYYY', locale: 'es',
        //maxDate: new Date(fechaAhora.getFullYear(), fechaAhora.getMonth(), fechaAhora.getDate() /*- 1*/),
        useCurrent: false
    });
    $('#dtFechaFFiltro').datetimepicker({
        format: 'DD/MM/YYYY', locale: 'es',
        //maxDate: new Date(fechaAhora.getFullYear(), fechaAhora.getMonth(), fechaAhora.getDate() /*- 1*/),
        useCurrent: false
    });
    $("#btnNuevo").click(function () {
        $("#myModal").modal("toggle");
    });
    $("#btnGuardar").click(addUser);
    $("#btnBuscar").click(function () {
        $table.bootstrapTable('refresh');
    });
    $("#btnLimpiar").click(limpiarFiltros);
    $("#btnCerrar").click(limpiarRegistros);

    listarUsuarios();
    validarRegistros();
});

const ajaxCall = (serviceName, dataString, ajaxSuccess, ajaxComplete, type = $_GET, async = false) => {
    $.ajax({
        type: type,
        contentType: 'application/json; charset=utf-8',
        url: controlador + serviceName,
        dataType: 'json',
        data: dataString,
        success: ajaxSuccess,
        complete: ajaxComplete,
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
        },
        //error: function (XMLHttpRequest, textStatus, errorThrown) {
        //    $("#ModalConexion").modal("show");
        //},
        async: async
    });
}

//GUARDAR USUARIO

const addUser = () => {

    if ($("#frmRegistro").valid()) {
        let params = {
            Email: $("#txtEmail").val(),
            DNI: $("#txtDni").val(),
            FirstName: $("#txtNombres").val(),
            LastName: $("#txtApellidos").val(),
            MobilePhone: $("#txtCelular").val()
        };

        let ajaxSucces = (data) => {
            if (data.Done) {
                $table.bootstrapTable('refresh');
            } else {
                $.each(data.Errors, function () {
                    alert(this.ErrorMessage);
                });
            }
        }

        let ajaxComplete = () => {
            $("#myModal").modal('hide');
            limpiarRegistros();
        }

        ajaxCall("AddUser", JSON.stringify(params), ajaxSucces, ajaxComplete, $_POST);
    }
    
}

//LISTAR USUARIOS

const listarUsuarios = () => {
    $table.bootstrapTable('destroy');
    $table.bootstrapTable({
        url: controlador + "ListUsers",
        method: $_POST,
        pagination: true,
        contentType: "application/json; charset=utf-8",
        sidePagination: 'server',
        queryParamsType: 'else',
        pageSize: 20,
        queryParams: function (p) {
            var pageNumber = p.pageNumber;
            var pageSize = p.pageSize;
            return JSON.stringify({
                fechaI: dateFromString($("#txtFechaI").val()),
                fechaF: dateFromString($("#txtFechaF").val()),
                nombre: $("#txtNombre").val(),
                pageNumber: pageNumber,
                pageSize: pageSize
            })
        },
        responseHandler: function (res) {
            var data = res;
            return { rows: data.ListUser, total: data.Total }
        }
    });
}


//LIMPIAR FILTROS

const limpiarFiltros = () => {
    $("#txtFechaI").val("");
    $("#txtFechaF").val("");
    $("#txtNombre").val("");
    $table.bootstrapTable('refresh');
}

//VALIDACION REGISTROS

const validarRegistros = () => {
   
    $("#frmRegistro").validate({
        ignore: ".ignore",
        errorClass: "my-error-class",
        validClass: "my-valid-class",
        rules: {
            txtNombres: {
                required: true
            },
            txtApellidos: {
                required: true
            },
            txtEmail: {
                required: true,
                email: true
            },
            txtDni: {
                required: true
            },
            txtCelular: {
                required: true,
                number: true
            }
        },
        messages: {
            txtNombres: {
                required: "Debe ingresar los nombres del usuario"
            },
            txtApellidos: {
                required: "Debe ingresar los apellidos del usuario"
            },
            txtEmail: {
                required: "Debe ingresar el correo del usuario",
                email: "Debe ingresar un correo válido"
            },
            txtDni: {
                required: "Debe ingresar el DNI del usuario"
            },
            txtCelular: {
                required: "Debe ingresar un celular del usuario",
                number: "De ingresar un celular válido"
            }
        }
    });
}

//LIMPIAR REGISTROS
const limpiarRegistros = () => {
    $("#frmRegistro :input").val("");
    $("#frmRegistro").validate().resetForm();
}
