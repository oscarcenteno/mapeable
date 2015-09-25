Namespace MapeadorDeProductos
    <TestClass()> Public Class Mapee_Tests

        Private elMapeador As MapeadorDeProductos
        Private elResultadoEsperado As ProductoDto
        Private elResultadoObtenido As ProductoDto
        Private elOrigen As Producto
        Private elProveedor As Proveedor

        <TestInitialize> Public Sub Inicialice()
            InicialiceElMapeador()
            InicialiceElOrigen()
            InicialiceElProveedor()
        End Sub

        Private Sub InicialiceElMapeador()
            elMapeador = New MapeadorDeProductos
        End Sub

        Private Sub InicialiceElOrigen()
            elOrigen = New Producto
            elOrigen.IdProducto = 99
            elOrigen.Nombre = "El Producto"
            elOrigen.Fecha = New Date(2015, 12, 12)
        End Sub

        Private Sub InicialiceElProveedor()
            elProveedor = New Proveedor
            elProveedor.Nombre = "El Proveedor"
            elOrigen.ElProveedor = elProveedor
        End Sub

        <TestMethod()> Public Sub Mapee_PropiedadesPersonalizadas_DestinoEsperado()
            elResultadoEsperado = CreeElEsperado()

            elMapeador = New MapeadorDeProductos
            elResultadoObtenido = elMapeador.Mapee(elOrigen)

            Assert.IsTrue(elResultadoEsperado.EsIgualQue(elResultadoObtenido))
        End Sub

        Private Function CreeElEsperado() As ProductoDto
            Dim elResultadoEsperado As New ProductoDto
            elResultadoEsperado.Id = 99
            elResultadoEsperado.Nombre = "El Producto"
            elResultadoEsperado.Fecha = New Date(2015, 12, 12)
            elResultadoEsperado.NombreDelProveedor = "El Proveedor"

            Return elResultadoEsperado
        End Function

    End Class
End Namespace
