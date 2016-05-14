Imports Mapeable.ComparacionesParaPruebasUnitarias

<TestClass()> Public Class Mapee_Tests

    Private elMapeo As Mapeo(Of Producto, RegistroDeUnProducto)
    Private elOrigen As Producto
    Private elResultadoObtenido As RegistroDeUnProducto
    Private elResultadoEsperado As RegistroDeUnProducto

    <TestInitialize> Public Sub Inicializar()
        InicialiceElMapeo()
        InicialiceElOrigen()
    End Sub

    Private Sub InicialiceElMapeo()
        elMapeo = New Mapeo(Of Producto, RegistroDeUnProducto)
    End Sub

    Private Sub InicialiceElOrigen()
        elOrigen = New Producto
        elOrigen.Nombre = "El Producto"
        elOrigen.Fecha = New Date(2015, 12, 12)
    End Sub

    <TestMethod()> Public Sub Mapee_PropiedadesUnoAUno_DestinoEsperado()
        elResultadoEsperado = InicialiceElEsperado()

        elResultadoObtenido = elMapeo.Mapee(elOrigen)

        Verificacion.SonIguales(elResultadoEsperado, elResultadoObtenido)
    End Sub

    Private Function InicialiceElEsperado() As RegistroDeUnProducto
        Dim elProducto As New RegistroDeUnProducto
        elProducto.Nombre = "El Producto"
        elProducto.Fecha = New Date(2015, 12, 12)
        Return elProducto
    End Function
End Class