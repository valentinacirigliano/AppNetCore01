var tablaProductos;
$(document).ready(function () {
    tablaProductos = $('#tblProductos').DataTable({
        "ajax": {
            "url": "/Producto/GetAll"
        },
        "columns": [

            { "data": "descripcion" },
            { "data": "codigo" },
            { "data": "marca" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                                <a class="btn btn-warning" href="/Producto/UpSert?id=${data}" >
                                    <i class="bi bi-pencil-square"></i>&nbsp;
                                    Editar
                                </a>
                                <a class="btn btn-danger" onclick="Delete('/Producto/Delete/${data}')" >
                                    <i class="bi bi-trash3"></i> &nbsp;
                                    Eliminar
                                </a>

                            `
                }
            }
        ]
        
    });
});


function Delete(url) {
    Swal.fire({
        title: '¿Estás seguro?',
        text: "¡No podrás revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí, eliminarlo'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                "url": url,
                "type": 'DELETE',
                "success": function (data) {
                    console.log(data);
                    if (data.success) {
                        tablaProductos.ajax.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
