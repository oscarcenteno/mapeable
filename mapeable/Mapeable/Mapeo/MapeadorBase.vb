Imports System.Linq.Expressions

Public Class MapeadorBase(Of ClaseOrigen, ClaseDestino)

    Private elMapeador As MapeadorDePropiedades(Of ClaseOrigen, ClaseDestino)

    Public Sub New()
        EncuentreLosMapeosDePropiedadesPublicasEntreLasClases()
    End Sub

    Protected Function LaPropiedad(Of TipoDeLaPropiedad) _
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