Imports System.Linq.Expressions

Public Class Mapeador(Of ClaseOrigen, ClaseDestino)

    Private elMapeadorDePropiedades As MapeadorDePropiedades(Of ClaseOrigen, ClaseDestino)

    Public Sub New()
        EncuentreLosMapeosDePropiedadesPublicasEntreLasClases()
    End Sub

    Friend Function LaPropiedad(Of TProperty)(expresion As Expression(Of Func(Of ClaseDestino, TProperty))) As MapeoDePropiedad(Of ClaseOrigen, ClaseDestino)
        'elMapeadorDePropiedades.RegistreUnNuevoMapeo ( )
        Throw New NotImplementedException
    End Function

    Public Function Mapee(objetoDeClaseOrigen As ClaseOrigen) As ClaseDestino
        Return ApliqueLosMapeosEncontradosALosObjetos(objetoDeClaseOrigen)
    End Function

    Private Function ApliqueLosMapeosEncontradosALosObjetos(objetoDeClaseOrigen As ClaseOrigen) As ClaseDestino
        Dim elResultadoDelMapeo As ClaseDestino
        elResultadoDelMapeo = elMapeadorDePropiedades.Mapee(objetoDeClaseOrigen)
        Return elResultadoDelMapeo
    End Function

    Private Sub EncuentreLosMapeosDePropiedadesPublicasEntreLasClases()
        Dim elBuscador As New BuscadorDeMapeos(Of ClaseOrigen, ClaseDestino)()
        Me.elMapeadorDePropiedades = elBuscador.EncuentreMapeos()
    End Sub

End Class