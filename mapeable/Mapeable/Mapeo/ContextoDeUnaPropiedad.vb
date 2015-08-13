Imports System.Reflection

Public Class ContextoDeUnaPropiedad
    Private Property instanciaOrigen As Object
    Public Property elMapeo As MapeoPersonalizado
    Private elContenedorDelValorDeLaPropiedadOrigen As Lazy(Of Object)

    Public Sub New(instanciaOrigen As Object,
                   elMapeo As MapeoPersonalizado)
        Me.instanciaOrigen = instanciaOrigen
        Me.elMapeo = elMapeo
        Me.elContenedorDelValorDeLaPropiedadOrigen = New Lazy(Of Object) _
            (Function() elMapeo.LaExpresionOrigen(instanciaOrigen))
    End Sub

    Public Sub AsigneA(instanciaDestino As Object)
        Dim elTipoDelDestino As Type
        elTipoDelDestino = instanciaDestino.GetType()

        Dim losAtributos As BindingFlags = BindingFlags.Instance Or BindingFlags.Public

        Dim laPropiedad As PropertyInfo
        laPropiedad = elTipoDelDestino.GetProperty(elMapeo.LaPropiedadDestino,
                                                   losAtributos)

        Dim elValorPorMapear As Object
        elValorPorMapear = elContenedorDelValorDeLaPropiedadOrigen.Value

        laPropiedad.SetValue(instanciaDestino, elValorPorMapear, Nothing)
    End Sub

End Class
