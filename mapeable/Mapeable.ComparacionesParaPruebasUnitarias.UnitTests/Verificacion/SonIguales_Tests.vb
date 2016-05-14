Imports Mapeable.ComparacionesParaPruebasUnitarias
Imports Mapeable.UnitTests

<TestClass()>
Public Class SonIguales_Tests
    Private elResultadoEsperado As Producto
    Private elResultadoObtenido As Producto

    Private Function ObtengaUnProducto() As Producto
        Dim elProducto = New Producto
        elProducto.IdProducto = 99
        elProducto.Nombre = "El Nombre"
        elProducto.Fecha = New Date(2015, 9, 30)
        elProducto.Precio = 10.5789
        Return elProducto
    End Function

    Private Function ObtengaUnProveedor() As Proveedor
        Dim unProveedor As New Proveedor
        unProveedor.Id = 501
        unProveedor.Nombre = "El Proveedor"
        unProveedor.Direccion = "San Jose"
        Return unProveedor
    End Function

    Private Function ObtengaOtroProvedor() As Proveedor
        Dim otroProveedor As New Proveedor
        otroProveedor.Id = 501
        otroProveedor.Nombre = "El otro Proveedor"
        otroProveedor.Direccion = "San Jose"
        Return otroProveedor
    End Function

    <TestMethod(), ExpectedException(GetType(AssertFailedException))>
    Public Sub SonIguales_Tests_EsteObjetoEsNulo_No()
        elResultadoEsperado = Nothing

        elResultadoObtenido = ObtengaUnProducto()

        Verificacion.SonIguales(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod(), ExpectedException(GetType(AssertFailedException))>
    Public Sub SonIguales_Tests_LosTiposSonDiferentes_No()
        elResultadoEsperado = ObtengaUnProducto()

        Dim unProveedor As New Proveedor

        Verificacion.SonIguales(elResultadoEsperado, unProveedor)
    End Sub

    <TestMethod(), ExpectedException(GetType(AssertFailedException))>
    Public Sub SonIguales_Tests_ElOtroObjetoEsNulo_No()
        elResultadoEsperado = ObtengaUnProducto()

        elResultadoObtenido = Nothing

        Verificacion.SonIguales(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod(), ExpectedException(GetType(AssertFailedException))>
    Public Sub SonIguales_Tests_EsteObjetoTieneValoresPorDefecto_No()
        elResultadoEsperado = New Producto

        elResultadoObtenido = ObtengaUnProducto()

        Verificacion.SonIguales(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod(), ExpectedException(GetType(AssertFailedException))>
    Public Sub SonIguales_Tests_ElOtroObjetoTieneValoresPorDefecto_No()
        elResultadoEsperado = ObtengaUnProducto()

        elResultadoObtenido = New Producto

        Verificacion.SonIguales(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()>
    Public Sub SonIguales_Tests_PropiedadesSonTiposYSonIguales_Si()
        elResultadoEsperado = ObtengaUnProducto()

        elResultadoObtenido = ObtengaUnProducto()

        Verificacion.SonIguales(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod(), ExpectedException(GetType(AssertFailedException))>
    Public Sub SonIguales_Tests_PropiedadesSonTiposUnaEsDiferente_No()
        elResultadoEsperado = ObtengaUnProducto()

        elResultadoObtenido = ObtengaUnProducto()
        elResultadoObtenido.Nombre = "Otro Nombre"

        Verificacion.SonIguales(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()>
    Public Sub SonIguales_Tests_LasPropiedadesObjetosSonIguales_Si()
        elResultadoEsperado = ObtengaUnProducto()
        elResultadoEsperado.ElProveedor = ObtengaUnProveedor()

        elResultadoObtenido = ObtengaUnProducto()
        elResultadoObtenido.ElProveedor = ObtengaUnProveedor()

        Verificacion.SonIguales(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod(), ExpectedException(GetType(AssertFailedException))>
    Public Sub SonIguales_Tests_UnaPropiedadObjetoTieneUnaPropiedadDiferente_No()
        elResultadoEsperado = ObtengaUnProducto()
        elResultadoEsperado.ElProveedor = ObtengaUnProveedor()

        elResultadoObtenido = ObtengaUnProducto()
        elResultadoObtenido.ElProveedor = ObtengaOtroProvedor()

        Verificacion.SonIguales(elResultadoEsperado, elResultadoObtenido)
    End Sub
End Class