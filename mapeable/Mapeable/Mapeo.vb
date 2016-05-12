Imports System.Linq.Expressions
Imports Mapeable.Mapeos

Public Class Mapeo(Of ClaseOrigen, ClaseDestino As New)
    Private elMapeador As MapeadorDePropiedades(Of ClaseOrigen, ClaseDestino)

    Public Sub New()
        EncuentreLosMapeosDePropiedadesPublicasEntreLasClases()
    End Sub

    Protected Function Desde(Of TipoDeLaPropiedad) _
        (laPropiedadOrigen As Expression(Of Func(Of ClaseOrigen, TipoDeLaPropiedad))) _
        As ConfiguradorDeMapeoPersonalizado(Of ClaseDestino, TipoDeLaPropiedad)

        Dim elMapeo As MapeoPersonalizado
        elMapeo = MapeoPersonalizado.Cree(laPropiedadOrigen)
        elMapeador.RegistreUnMapeoPersonalizado(elMapeo)

        Dim elConfigurador As ConfiguradorDeMapeoPersonalizado(Of ClaseDestino,
                                                               TipoDeLaPropiedad)
        elConfigurador = New ConfiguradorDeMapeoPersonalizado(Of ClaseDestino,
                                                              TipoDeLaPropiedad)(elMapeo)
        Return elConfigurador
    End Function

    Public Function Mapee(elObjetoOrigen As ClaseOrigen) As ClaseDestino
        Return elMapeador.Mapee(elObjetoOrigen)
    End Function

    Private Sub EncuentreLosMapeosDePropiedadesPublicasEntreLasClases()
        Dim elBuscador As New BuscadorDeMapeos(Of ClaseOrigen, ClaseDestino)()
        elMapeador = elBuscador.EncuentreMapeos()
    End Sub

End Class