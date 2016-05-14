Imports Mapeable.ComparacionesParaPruebasUnitarias
Imports Mapeable.UnitTests

<TestClass()>
Public Class LasListasSonIguales_Tests
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

    <TestMethod()>
    Public Sub LasListasSonIguales_AmbasSonNulas_Si()
        unosProductos = Nothing

        otrosProductos = Nothing

        Verificacion.LasListasSonIguales(unosProductos, otrosProductos)
    End Sub

    <TestMethod(), ExpectedException(GetType(AssertFailedException))>
    Public Sub LasListasSonIguales_UnosProductosEsNulo_No()
        unosProductos = Nothing

        Verificacion.LasListasSonIguales(unosProductos, otrosProductos)
    End Sub

    <TestMethod(), ExpectedException(GetType(AssertFailedException))>
    Public Sub LasListasSonIguales_LosTiposSonDiferentes_No()
        elResultadoEsperado = False

        Verificacion.LasListasSonIguales(unosProductos, unosProveedores)
    End Sub

    <TestMethod(), ExpectedException(GetType(AssertFailedException))>
    Public Sub LasListasSonIguales_LaOtraColeccionEsNula_No()
        otrosProductos = Nothing

        Verificacion.LasListasSonIguales(unosProductos, otrosProductos)
    End Sub

    <TestMethod(), ExpectedException(GetType(AssertFailedException))>
    Public Sub LasListasSonIguales_TienenCantidadDeElementosDiferente_No()
        unosProductos.Add(New Producto)

        Verificacion.LasListasSonIguales(unosProductos, otrosProductos)
    End Sub

    <TestMethod()>
    Public Sub LasListasSonIguales_LaColeccionesSonVacias_Si()
        otrosProductos = New List(Of Producto)

        unosProductos = New List(Of Producto)

        Verificacion.LasListasSonIguales(unosProductos, otrosProductos)
    End Sub

    <TestMethod()> Public Sub LasListasSonIguales_LosObjectosEnElMismoOrdenSonIguales_Si()
        Verificacion.LasListasSonIguales(unosProductos, otrosProductos)
    End Sub

    <TestMethod(), ExpectedException(GetType(AssertFailedException))>
    Public Sub LasListasSonIguales_UnObjetoEsDiferente_No()
        unosProductos.Add(New Producto)
        otrosProductos.Add(New Producto With {.IdProducto = 9900})

        Verificacion.LasListasSonIguales(unosProductos, otrosProductos)
    End Sub
End Class