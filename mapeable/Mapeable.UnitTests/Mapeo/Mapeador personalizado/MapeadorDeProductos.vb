Namespace MapeadorDeProductos
    Class MapeadorDeProductos
        Inherits Mapeador(Of Producto, ProductoDto)

        Public Sub New()
            LaPropiedad(Function(origen) origen.IdProducto).
                MapeaHacia(Function(destino) destino.Id)
            LaPropiedad(Function(origen) origen.ElProveedor.Nombre).
                MapeaHacia(Function(destino) destino.NombreDelProveedor)
        End Sub

    End Class
End Namespace