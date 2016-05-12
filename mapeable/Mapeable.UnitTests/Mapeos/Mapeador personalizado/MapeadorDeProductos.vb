Namespace MapeadorDeProductos
    Class MapeoDeProductos
        Inherits Mapeo(Of Producto, RegistroDeUnProducto)

        Public Sub New()
            Desde(Function(origen) origen.IdProducto).
                Hacia(Function(destino) destino.Id)
            Desde(Function(origen) origen.ElProveedor.Nombre).
                Hacia(Function(destino) destino.NombreDelProveedor)
        End Sub
    End Class
End Namespace