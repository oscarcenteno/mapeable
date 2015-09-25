<TestClass()> Public Class Mapee_Tests

    Private elMapeador As Mapeador(Of Producto, ProductoDto)
    Private elOrigen As Producto
    Private elResultadoObtenido As ProductoDto
    Private elResultadoEsperado As ProductoDto

    <TestInitialize> Public Sub Inicializar()
        InicialiceElMapeador()
        InicialiceElOrigen()
    End Sub

    Private Sub InicialiceElMapeador()
        elMapeador = New Mapeador(Of Producto, ProductoDto)
    End Sub

    Private Sub InicialiceElOrigen()
        elOrigen = New Producto
        elOrigen.Nombre = "El Producto"
        elOrigen.Fecha = New Date(2015, 12, 12)
    End Sub

    <TestMethod()> Public Sub Mapee_PropiedadesUnoAUno_DestinoEsperado()
        elResultadoEsperado = InicialiceElEsperado()

        elResultadoObtenido = elMapeador.Mapee(elOrigen)

        Assert.IsTrue(elResultadoEsperado.EsIgualQue(elResultadoObtenido))
    End Sub

    Private Function InicialiceElEsperado() As ProductoDto
        Dim elProducto As New ProductoDto
        elProducto.Nombre = "El Producto"
        elProducto.Fecha = New Date(2015, 12, 12)

        Return elProducto
    End Function

End Class





