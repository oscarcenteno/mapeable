Imports Mapeable.ComparacionesParaPruebasUnitarias

<TestClass()>
Public Class MapeeLaColeccion_Tests
    Private elMapeo As MapeoDeColecciones(Of Producto, RegistroDeUnProducto)
    Private elResultadoEsperado As Boolean
    Private elResultadoObtenido As Boolean
    Private losProductos As List(Of Producto)
    Private losObtenidos As List(Of RegistroDeUnProducto)
    Private losEsperados As List(Of RegistroDeUnProducto)

    <TestInitialize> Public Sub Inicialice()
        InicialiceElMapeador()
        InicialiceLaColeccionDeProductos()
        CreeLosProductos()
        InicialiceLaColeccionEsperada()
        CreeLosEsperados()
    End Sub

    Private Sub InicialiceLaColeccionDeProductos()
        losProductos = New List(Of Producto)
    End Sub

    Private Sub InicialiceLaColeccionEsperada()
        losEsperados = New List(Of RegistroDeUnProducto)
    End Sub

    Private Sub InicialiceElMapeador()
        elMapeo = New MapeoDeColecciones(Of Producto, RegistroDeUnProducto)
    End Sub

    Private Sub CreeLosProductos()
        losProductos = New List(Of Producto)
        losProductos.Add(New Producto With {.Nombre = "N9",
                                            .Fecha = New Date(2019, 9, 9)})
        losProductos.Add(New Producto With {.Nombre = "N8",
                                            .Fecha = New Date(2018, 8, 8)})
        losProductos.Add(New Producto With {.Nombre = "N7",
                                            .Fecha = New Date(2017, 7, 7)})
    End Sub

    Private Sub CreeLosEsperados()
        losEsperados = New List(Of RegistroDeUnProducto)
        losEsperados.Add(New RegistroDeUnProducto With {.Nombre = "N9",
                                               .Fecha = New Date(2019, 9, 9)})
        losEsperados.Add(New RegistroDeUnProducto With {.Nombre = "N8",
                                               .Fecha = New Date(2018, 8, 8)})
        losEsperados.Add(New RegistroDeUnProducto With {.Nombre = "N7",
                                               .Fecha = New Date(2017, 7, 7)})
    End Sub

    <TestMethod()> Public Sub MapeeLaColeccion_EsNula_Vacia()
        losEsperados = New List(Of RegistroDeUnProducto)

        losProductos = Nothing
        losObtenidos = elMapeo.Mapee(losProductos)

        Verificacion.LasListasSonIguales(losEsperados, losObtenidos)
    End Sub

    <TestMethod()> Public Sub MapeeLaColeccion_EsVacia_Vacia()
        losEsperados = New List(Of RegistroDeUnProducto)

        losProductos = New List(Of Producto)
        losObtenidos = elMapeo.Mapee(losProductos)

        Verificacion.LasListasSonIguales(losEsperados, losObtenidos)
    End Sub

    <TestMethod()> Public Sub MapeeLaColeccion_TieneTresElementos_TresMapeados()
        losObtenidos = elMapeo.Mapee(losProductos)

        Verificacion.LasListasSonIguales(losEsperados, losObtenidos)
    End Sub
End Class