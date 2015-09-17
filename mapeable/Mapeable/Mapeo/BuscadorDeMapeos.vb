
Class BuscadorDeMapeos(Of ClaseOrigen, ClaseDestino)

    Private elMapeador As MapeadorDePropiedades(Of ClaseOrigen, ClaseDestino)
    Private lasPropiedadesEnElOrigen As IEnumerable(Of Propiedad)
    Private lasPropiedadesEnElDestino As IEnumerable(Of Propiedad)

    Public Sub New()
        elMapeador = New MapeadorDePropiedades(Of ClaseOrigen, ClaseDestino)()
    End Sub

    Function EncuentreMapeos() As MapeadorDePropiedades(Of ClaseOrigen, ClaseDestino)
        EncuentreLasPropiedadesEnElDestino()
        EncuentreLasPropiedadesEnElOrigen()
        RegistreLosEquivalentesDelDestinoEnElOrigen()

        Return elMapeador
    End Function

    Private Sub EncuentreLasPropiedadesEnElDestino()
        Dim elTipo As Type = GetType(ClaseDestino)
        Dim elBuscador = New BuscadorDePropiedadesEscribibles(elTipo)
        lasPropiedadesEnElDestino = elBuscador.EncuentreLasPropiedadesEscribibles()
    End Sub

    Private Sub EncuentreLasPropiedadesEnElOrigen()
        If HayPropiedadesEnElDestino() Then
            Dim elTipo As Type = GetType(ClaseOrigen)
            Dim elBuscador = New BuscadorDePropiedadesLegibles(elTipo)
            lasPropiedadesEnElOrigen = elBuscador.EncuentreLasPropiedadesLegibles()
        End If
    End Sub

    Private Sub RegistreLosEquivalentesDelDestinoEnElOrigen()
        For Each laPropiedadEnElDestino In lasPropiedadesEnElDestino
            RegistreSiSeEncuentraEnElOrigen(laPropiedadEnElDestino)
        Next
    End Sub

    Private Sub RegistreSiSeEncuentraEnElOrigen(laPropiedadEnElDestino As Propiedad)
        For Each unaPropiedadEnElOrigen In lasPropiedadesEnElOrigen
            If unaPropiedadEnElOrigen.EsIgualQue(laPropiedadEnElDestino) Then
                elMapeador.RegistreUnNuevoMapeo(unaPropiedadEnElOrigen,
                                                laPropiedadEnElDestino)
                Exit For
            End If
        Next
    End Sub

    Private Function HayPropiedadesEnElDestino() As Boolean
        Return lasPropiedadesEnElDestino.Count > 0
    End Function

End Class
