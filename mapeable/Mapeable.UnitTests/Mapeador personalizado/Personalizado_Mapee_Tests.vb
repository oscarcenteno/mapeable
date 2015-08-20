Namespace MapeadorDeProductos

    <TestClass()> Public Class Mapee_Tests

        Private elMapeador As MapeadorDeProductos
        Private elResultadoObtenido As ProductoDto
        Private elResultadoEsperado As ProductoDto
        Private origen As Producto
        Private elProveedor As Proveedor

        <TestInitialize> Public Sub Inicializar()
            InicialiceElEsperado()
            InicialiceElMapeador()
            InicialiceElOrigen()
            InicialiceElProveedor()
        End Sub

        Private Sub InicialiceElEsperado()
            elResultadoEsperado = New ProductoDto
            elResultadoEsperado.Id = 99
            elResultadoEsperado.Nombre = "El Producto"
            elResultadoEsperado.Fecha = New Date(2015, 12, 12)
            elResultadoEsperado.NombreDelProveedor = "El Proveedor"
        End Sub

        Private Sub InicialiceElMapeador()
            elMapeador = New MapeadorDeProductos
        End Sub

        Private Sub InicialiceElOrigen()
            origen = New Producto
            origen.IdProducto = 99
            origen.Nombre = "El Producto"
            origen.Fecha = New Date(2015, 12, 12)
        End Sub

        Private Sub InicialiceElProveedor()
            elProveedor = New Proveedor
            elProveedor.Nombre = "El Proveedor"
            origen.ElProveedor = elProveedor
        End Sub

        <TestMethod()> Public Sub Mapee_PropiedadesPersonalizadas_DestinoEsperado()


            elMapeador = New MapeadorDeProductos
            elResultadoObtenido = elMapeador.Mapee(origen)

            Assert.IsTrue(elResultadoEsperado.EsIgualQue(elResultadoObtenido))
        End Sub

    End Class

End Namespace
