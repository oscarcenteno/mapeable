﻿Namespace MapeadorDeProductos

    Class MapeadorDeProductos
        Inherits MapeadorBase(Of Producto, ProductoDto)

        Public Sub New()

            LaPropiedad(Function(origen) origen.IdProducto) _
                .MapeaHacia(Function(destino) destino.Id)

            LaPropiedad(Function(origen) origen.ElProveedor.Nombre) _
                .MapeaHacia(Function(destino) destino.NombreDelProveedor)

        End Sub

    End Class

End Namespace