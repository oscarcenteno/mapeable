<TestClass()> Public Class Mapee_Tests

    Private elMapeador As Mapeador(Of Producto, ProductoDto)
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
        elResultadoEsperado.Nombre = "El Producto"
        elResultadoEsperado.Fecha = New Date(2015, 12, 12)
    End Sub

    Private Sub InicialiceElMapeador()
        elMapeador = New Mapeador(Of Producto, ProductoDto)
    End Sub

    Private Sub InicialiceElOrigen()
        origen = New Producto
        origen.Nombre = "El Producto"
        origen.Fecha = New Date(2015, 12, 12)
    End Sub

    Private Sub InicialiceElProveedor()
        elProveedor = New Proveedor
        elProveedor.Nombre = "El Proveedor"
    End Sub

    <TestMethod()> Public Sub Mapee_PropiedadesUnoAUno_DestinoEsperado()
        elResultadoObtenido = elMapeador.Mapee(origen)

        Assert.IsTrue(elResultadoEsperado.EsIgualQue(elResultadoObtenido))
    End Sub

End Class





