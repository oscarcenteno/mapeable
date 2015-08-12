Imports System.Linq.Expressions

Public Class MapeadorBase(Of ClaseOrigen, ClaseDestino)

    Private elMapeador As MapeadorDePropiedades(Of ClaseOrigen, ClaseDestino)

    Public Sub New()
        EncuentreLosMapeosDePropiedadesPublicasEntreLasClases()
    End Sub

    Protected Function MapeeLaPropiedadAOtra(Of TipoDeLaPropiedad) _
        (propiedadOrigen As Expression(Of Func(Of ClaseOrigen, TipoDeLaPropiedad)),
         propiedadDestino As Expression(Of Func(Of ClaseDestino, TipoDeLaPropiedad))) _
     As MapeoDePropiedad(Of ClaseOrigen, ClaseDestino)

        Throw New NotImplementedException
    End Function

    Public Function Mapee(objetoDeClaseOrigen As ClaseOrigen) As ClaseDestino
        Dim elResultadoDelMapeo As ClaseDestino
        elResultadoDelMapeo = elMapeador.Mapee(objetoDeClaseOrigen)
        Return elResultadoDelMapeo
    End Function

    Private Sub EncuentreLosMapeosDePropiedadesPublicasEntreLasClases()
        Dim elBuscador As New BuscadorDeMapeos(Of ClaseOrigen, ClaseDestino)()
        Me.elMapeador = elBuscador.EncuentreMapeos()
    End Sub

End Class