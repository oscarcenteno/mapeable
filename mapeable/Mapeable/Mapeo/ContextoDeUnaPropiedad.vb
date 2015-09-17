Imports System.Reflection

Public Class ContextoDeUnaPropiedad

    Public Property elMapeo As MapeoPersonalizado

    Private Property laInstanciaOrigen As Object
    Private elContenedorDelValorDeLaPropiedad As Lazy(Of Object)

    Public Sub New(laInstanciaOrigen As Object,
                   elMapeo As MapeoPersonalizado)
        Me.laInstanciaOrigen = laInstanciaOrigen
        Me.elMapeo = elMapeo
        Me.elContenedorDelValorDeLaPropiedad = New Lazy(Of Object) _
            (Function() elMapeo.LaExpresionOrigen(laInstanciaOrigen))
    End Sub

    Public Sub AsigneA(laInstanciaDestino As Object)
        Dim elTipoDelDestino As Type
        elTipoDelDestino = laInstanciaDestino.GetType()

        Dim losFiltros As BindingFlags
        losFiltros = BindingFlags.Instance Or BindingFlags.Public

        Dim laPropiedad As PropertyInfo
        laPropiedad = elTipoDelDestino.GetProperty(elMapeo.LaPropiedadDestino, losFiltros)

        Dim elValorPorMapear As Object
        elValorPorMapear = elContenedorDelValorDeLaPropiedad.Value

        laPropiedad.SetValue(laInstanciaDestino, elValorPorMapear, Nothing)
    End Sub

End Class
