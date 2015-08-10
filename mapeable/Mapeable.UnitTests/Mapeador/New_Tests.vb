Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class New_Tests

    Dim elMapeador As Mapeador(Of Producto, ProductoDto)
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
        elMapeador = New Mapeador(Of Producto, ProductoDto)
    End Sub

    Private Sub InicialiceElOrigen()
        origen = New Producto
        origen.Id = 99
        origen.Nombre = "El Producto"
        origen.Fecha = New Date(2015, 12, 12)
    End Sub

    <TestMethod()> Public Sub New_PropiedadesUnoAUno_DestinoEsperado()

        Dim elResultadoObtenido As ProductoDto
        elResultadoObtenido = elMapeador.Mapee(origen)

        Assert.AreEqual(elResultadoEsperado, elResultadoObtenido)
    End Sub

    <TestMethod()> Public Sub New_AmbosSonObjects_UnNuevoObjeto()
    End Sub

End Class

Class Producto
    Public Property Id As Integer
    Public Property Nombre As String
    Public Property Fecha As Date
    Public Property IdProveedor As Integer

End Class

Class Proveedor
    Public Property Id As Integer
    Public Property Nombre As String
    Public Property Direccion As String

End Class

Class ProductoDto
    Implements IEquatable(Of ProductoDto)
    Public Property Id As Integer
    Public Property Nombre As String
    Public Property Fecha As Date
    Public Property NombreDelProveedor As String

    Public Overloads Function Equals(elOtro As ProductoDto) As Boolean Implements IEquatable(Of ProductoDto).Equals
        Dim sonIguales As Boolean

        sonIguales = Integer.Equals(Me.Id, elOtro.Id)
        sonIguales = sonIguales And String.Equals(Me.Nombre, elOtro.Nombre)
        sonIguales = sonIguales And Date.Equals(Me.Fecha, elOtro.Fecha)
        sonIguales = sonIguales And String.Equals(Me.NombreDelProveedor, elOtro.NombreDelProveedor)

        Return sonIguales
    End Function

    Public Overloads Overrides Function Equals(obj As Object) As Boolean

        If obj Is Nothing OrElse Not Me.GetType() Is obj.GetType() Then
            Return False
        End If

        Dim otroDestino As ProductoDto
        otroDestino = obj

        Return Me.Equals(otroDestino)
    End Function

End Class