<TestClass()> Public Class EsIgualQue_Tests

    Dim elResultadoEsperado As Boolean
    Dim elResultadoObtenido As Boolean
    Dim unProducto As Producto
    Dim elOtroProducto As Producto
    Dim unProveedor As Proveedor
    Dim elOtroProveedor As Proveedor

    <TestInitialize> Public Sub Inicializar()
        InicialiceUnProvedor()
        InicialiceElOtroProvedor()
        InicialiceUnProducto()
        InicialiceElOtroProducto()
    End Sub

    <TestMethod()> Public Sub EsIgualQue_EsteObjetoEsNulo_No()
        elResultadoEsperado = False
        unProducto = Nothing
        elResultadoObtenido = unProducto.EsIgualQue(elOtroProducto)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub EsIgualQue_LosTiposSonDireferentes_No()
        elResultadoEsperado = False
        elResultadoObtenido = unProducto.EsIgualQue(unProveedor)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub


    <TestMethod()> Public Sub EsIgualQue_ElOtroObjetoEsNulo_No()
        elResultadoEsperado = False
        elOtroProducto = Nothing
        elResultadoObtenido = unProducto.EsIgualQue(elOtroProducto)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub EsIgualQue_EsteObjetoTieneValoresPorDefecto_No()
        elResultadoEsperado = False
        unProducto = New Producto
        elResultadoObtenido = unProducto.EsIgualQue(elOtroProducto)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub EsIgualQue_ElOtroObjetoTieneValoresPorDefecto_No()
        elResultadoEsperado = False
        elOtroProducto = New Producto
        elResultadoObtenido = unProducto.EsIgualQue(elOtroProducto)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub EsIgualQue_PropiedadesSonTiposYSonIguales_Si()
        elResultadoEsperado = True
        elResultadoObtenido = unProducto.EsIgualQue(elOtroProducto)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub EsIgualQue_PropiedadesSonTiposUnaEsDiferente_No()
        elResultadoEsperado = False
        elOtroProducto.Nombre = "Otro Nombre"
        elResultadoObtenido = unProducto.EsIgualQue(elOtroProducto)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub EsIgualQue_LasPropiedadesObjetosSonIguales_Si()
        elResultadoEsperado = True

        elOtroProducto.ElProveedor = elOtroProveedor
        unProducto.ElProveedor = unProveedor
        elResultadoObtenido = unProducto.EsIgualQue(elOtroProducto)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub EsIgualQue_UnaPropiedadObjetoTieneUnaPropiedadDiferente_No()
        elResultadoEsperado = False

        elOtroProducto.ElProveedor = elOtroProveedor
        unProducto.ElProveedor = unProveedor
        elOtroProveedor.Nombre = "Otro nombre de proveedor"
        elResultadoObtenido = unProducto.EsIgualQue(elOtroProducto)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    Private Sub InicialiceUnProducto()
        unProducto = New Producto
        unProducto.IdProducto = 99
        unProducto.Nombre = "El Nombre"
        unProducto.Fecha = New Date(2015, 9, 30)
        unProducto.Precio = 10.5789
    End Sub

    Private Sub InicialiceUnProvedor()
        unProveedor = New Proveedor
        unProveedor.Id = 501
        unProveedor.Nombre = "El Proveedor"
        unProveedor.Direccion = "San Jose"
    End Sub

    Private Sub InicialiceElOtroProducto()
        elOtroProducto = New Producto
        elOtroProducto.IdProducto = 99
        elOtroProducto.Nombre = "El Nombre"
        elOtroProducto.Fecha = New Date(2015, 9, 30)
        elOtroProducto.Precio = 10.5789
    End Sub

    Private Sub InicialiceElOtroProvedor()
        elOtroProveedor = New Proveedor
        elOtroProveedor.Id = 501
        elOtroProveedor.Nombre = "El Proveedor"
        elOtroProveedor.Direccion = "San Jose"
    End Sub

End Class
