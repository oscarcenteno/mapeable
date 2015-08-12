Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class Mapee_Tests

    Dim elMapeador As MapeadorBase(Of Producto, ProductoDto)
    Dim elResultadoObtenido As ProductoDto
    Dim elResultadoEsperado As ProductoDto
    Dim origen As Producto

    <TestInitialize> Public Sub Inicializar()
        InicialiceElEsperado()
        InicialiceElMapeador()
        InicialiceElOrigen()
    End Sub

    Private Sub InicialiceElEsperado()
        elResultadoEsperado = New ProductoDto
        elResultadoEsperado.Id = 99
        elResultadoEsperado.Nombre = "El Producto"
        elResultadoEsperado.Fecha = New Date(2015, 12, 12)
    End Sub

    Private Sub InicialiceElMapeador()
        elMapeador = New MapeadorBase(Of Producto, ProductoDto)
    End Sub

    Private Sub InicialiceElOrigen()
        origen = New Producto
        origen.Id = 99
        origen.Nombre = "El Producto"
        origen.Fecha = New Date(2015, 12, 12)
    End Sub

    <TestMethod()> Public Sub New_PropiedadesUnoAUno_DestinoEsperado()

        elResultadoObtenido = elMapeador.Mapee(origen)

        Assert.IsTrue(elResultadoEsperado.EsIgualQue(elResultadoObtenido))
    End Sub

End Class





