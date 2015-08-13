Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class Mapee_Tests

    Dim elMapeador As MapeadorBase(Of Producto, ProductoDto)
    Dim elResultadoObtenido As ProductoDto
    Dim elResultadoEsperado As ProductoDto
    Dim origen As Producto
    Dim elProveedor As Proveedor

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
        elMapeador = New MapeadorBase(Of Producto, ProductoDto)
    End Sub

    Private Sub InicialiceElOrigen()
        origen = New Producto
        origen.Nombre = "El Producto"
        origen.Fecha = New Date(2015, 12, 12)
    End Sub

    <TestMethod()> Public Sub Mapee_PropiedadesUnoAUno_DestinoEsperado()
        elResultadoObtenido = elMapeador.Mapee(origen)

        Assert.IsTrue(elResultadoEsperado.EsIgualQue(elResultadoObtenido))
    End Sub

    Private Sub InicialiceElProveedor()
        elProveedor = New Proveedor
        elProveedor.Nombre = "El Proveedor"
    End Sub


End Class





