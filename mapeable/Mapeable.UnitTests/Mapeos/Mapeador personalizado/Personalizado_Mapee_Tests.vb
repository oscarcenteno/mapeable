Imports Mapeable.ComparacionesParaPruebasUnitarias
Imports Mapeable.UnitTests.MapeadorDeProductos

Namespace MapeadorPersonalizado_Tests
    <TestClass()> Public Class Mapee_Tests
        Private elMapeo As MapeoDeProductos
        Private elResultadoEsperado As RegistroDeUnProducto
        Private elResultadoObtenido As RegistroDeUnProducto
        Private elOrigen As Producto
        Private elProveedor As Proveedor

        <TestInitialize> Public Sub Inicialice()
            InicialiceElMapeador()
            InicialiceElOrigen()
            InicialiceElProveedor()
        End Sub

        Private Sub InicialiceElMapeador()
            elMapeo = New MapeoDeProductos
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

            elMapeo = New MapeoDeProductos
            elResultadoObtenido = elMapeo.Mapee(elOrigen)

            Verificacion.SonIguales(elResultadoEsperado, elResultadoObtenido)
        End Sub

        Private Function CreeElEsperado() As RegistroDeUnProducto
            Dim elResultadoEsperado As New RegistroDeUnProducto
            elResultadoEsperado.Id = 99
            elResultadoEsperado.Nombre = "El Producto"
            elResultadoEsperado.Fecha = New Date(2015, 12, 12)
            elResultadoEsperado.NombreDelProveedor = "El Proveedor"

            Return elResultadoEsperado
        End Function
    End Class
End Namespace
