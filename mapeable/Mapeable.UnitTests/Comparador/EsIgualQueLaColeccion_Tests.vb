<TestClass()> Public Class EsIgualQueLaColeccion_Tests

    Private elResultadoEsperado As Boolean
    Private elResultadoObtenido As Boolean
    Private unosProductos As IList(Of Producto)
    Private otrosProductos As IList(Of Producto)
    Private unosProveedores As IList(Of Proveedor)

    <TestInitialize> Public Sub Inicialice()
        InicialiceUnosProductos()
        InicialiceOtrosProductos()
        InicialiceUnosProveedores()
    End Sub

    Private Sub InicialiceUnProducto(id As Integer)
        Dim unProducto As New Producto
        unProducto.IdProducto = id
        unProducto.Nombre = "El Nombre"
        unProducto.Fecha = New Date(2015, 9, 30)
        unProducto.Precio = 10.5789
        unosProductos.Add(unProducto)
    End Sub

    Private Sub InicialiceOtroProducto(id As Integer)
        Dim unProducto As New Producto
        unProducto.IdProducto = id
        unProducto.Nombre = "El Nombre"
        unProducto.Fecha = New Date(2015, 9, 30)
        unProducto.Precio = 10.5789
        otrosProductos.Add(unProducto)
    End Sub

    Private Sub InicialiceUnProveedor(id As Integer)
        Dim unProveedor As New Proveedor
        unProveedor.Id = id
        unProveedor.Nombre = "El Proveedor"
        unProveedor.Direccion = "San Jose"
        unosProveedores.Add(unProveedor)
    End Sub

    Private Sub InicialiceElOtroProducto()
        Dim unProducto As New Producto
        unProducto.IdProducto = 600
        unProducto.Nombre = "Otro Nombre"
        unProducto.Fecha = New Date(2016, 9, 30)
        unProducto.Precio = 11.1111
    End Sub

    Private Sub InicialiceUnosProductos()
        unosProductos = New List(Of Producto)
        InicialiceUnProducto(99)
        InicialiceUnProducto(501)
        InicialiceUnProducto(502)
    End Sub

    Private Sub InicialiceOtrosProductos()
        otrosProductos = New List(Of Producto)
        InicialiceOtroProducto(99)
        InicialiceOtroProducto(501)
        InicialiceOtroProducto(502)
    End Sub

    Private Sub InicialiceUnosProveedores()
        unosProveedores = New List(Of Proveedor)
        InicialiceUnProveedor(44)
        InicialiceUnProveedor(66)
    End Sub

    <TestMethod()> Public Sub EsIgualQueLaColeccion_AmbasSonNulas_Si()
        elResultadoEsperado = True

        unosProductos = Nothing
        otrosProductos = Nothing
        elResultadoObtenido = unosProductos.EsIgualQueLaColeccion(otrosProductos)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub EsIgualQueLaColeccion_UnosProductosEsNulo_No()
        elResultadoEsperado = False

        unosProductos = Nothing
        elResultadoObtenido = unosProductos.EsIgualQueLaColeccion(otrosProductos)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub EsIgualQueLaColeccion_LosTiposSonDiferentes_No()
        elResultadoEsperado = False

        elResultadoObtenido = unosProductos.EsIgualQueLaColeccion(unosProveedores)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub EsIgualQueLaColeccion_LaOtraColeccionEsNula_No()
        elResultadoEsperado = False
        otrosProductos = Nothing
        elResultadoObtenido = unosProductos.EsIgualQueLaColeccion(otrosProductos)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub EsIgualQueLaColeccion_TienenCantidadDeElementosDiferente_No()
        elResultadoEsperado = False
        unosProductos.Add(New Producto)
        elResultadoObtenido = unosProductos.EsIgualQueLaColeccion(otrosProductos)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub EsIgualQueLaColeccion_LaColeccionesSonVacias_Si()
        elResultadoEsperado = True
        otrosProductos = New List(Of Producto)
        unosProductos = New List(Of Producto)
        elResultadoObtenido = unosProductos.EsIgualQueLaColeccion(otrosProductos)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub EsIgualQueLaColeccion_LosObjectosEnElMismoOrdenSonIguales_Si()
        elResultadoEsperado = True
        elResultadoObtenido = unosProductos.EsIgualQueLaColeccion(otrosProductos)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub EsIgualQueLaColeccion_UnObjetoEsDiferente_No()
        elResultadoEsperado = False
        unosProductos.Add(New Producto)
        otrosProductos.Add(New Producto With {.IdProducto = 9900})
        elResultadoObtenido = unosProductos.EsIgualQueLaColeccion(otrosProductos)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub


End Class
