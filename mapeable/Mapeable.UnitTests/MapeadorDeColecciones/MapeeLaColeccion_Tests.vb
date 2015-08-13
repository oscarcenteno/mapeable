Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class MapeeLaColeccion_Tests

    Dim elMapeador As MapeadorDeColecciones(Of Producto, ProductoDto)
    Dim elResultadoEsperado As Boolean
    Dim elResultadoObtenido As Boolean
    Dim losProductos As IList(Of Producto)
    Dim losObtenidos As IList(Of ProductoDto)
    Dim losEsperados As IList(Of ProductoDto)

    <TestInitialize> Public Sub Inicialice()
        InicialiceElMapeador()
        InicialiceLaColeccionDeProductos()
        CreeLosProductos()
        InicialiceLaColeccionEsperada()
        CreeLosEsperados()
    End Sub

    <TestMethod()> Public Sub MapeeLaColeccion_EsNula_Vacia()
        elResultadoEsperado = True

        losEsperados = New List(Of ProductoDto)
        losProductos = Nothing
        losObtenidos = elMapeador.MapeeLaColeccion(losProductos)
        elResultadoObtenido = losEsperados.EsIgualQueLaColeccion(losObtenidos)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub MapeeLaColeccion_EsVacia_Vacia()
        elResultadoEsperado = True

        losEsperados = New List(Of ProductoDto)
        losProductos = New List(Of Producto)
        losObtenidos = elMapeador.MapeeLaColeccion(losProductos)
        elResultadoObtenido = losEsperados.EsIgualQueLaColeccion(losObtenidos)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub MapeeLaColeccion_TieneTresElementos_TresMapeados()
        elResultadoEsperado = True

        losObtenidos = elMapeador.MapeeLaColeccion(losProductos)
        elResultadoObtenido = losEsperados.EsIgualQueLaColeccion(losObtenidos)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub


    Private Sub InicialiceLaColeccionDeProductos()
        losProductos = New List(Of Producto)
    End Sub

    Private Sub InicialiceLaColeccionEsperada()
        losEsperados = New List(Of ProductoDto)
    End Sub

    Private Sub InicialiceElMapeador()
        elMapeador = New MapeadorDeColecciones(Of Producto, ProductoDto)
    End Sub

    Private Sub CreeLosProductos()
        losProductos = New List(Of Producto)
        losProductos.Add(New Producto With {.Id = 99, .IdProveedor = 9,
                                            .Nombre = "N9",
                                            .Fecha = New Date(2019, 9, 9)})
        losProductos.Add(New Producto With {.Id = 88, .IdProveedor = 8,
                                            .Nombre = "N8",
                                            .Fecha = New Date(2018, 8, 8)})
        losProductos.Add(New Producto With {.Id = 77, .IdProveedor = 7,
                                            .Nombre = "N7",
                                            .Fecha = New Date(2017, 7, 7)})
    End Sub

    Private Sub CreeLosEsperados()
        losEsperados = New List(Of ProductoDto)
        losEsperados.Add(New ProductoDto With {.Id = 99,
                                               .Nombre = "N9",
                                               .Fecha = New Date(2019, 9, 9)})
        losEsperados.Add(New ProductoDto With {.Id = 88,
                                               .Nombre = "N8",
                                               .Fecha = New Date(2018, 8, 8)})
        losEsperados.Add(New ProductoDto With {.Id = 77,
                                               .Nombre = "N7",
                                               .Fecha = New Date(2017, 7, 7)})
    End Sub

End Class