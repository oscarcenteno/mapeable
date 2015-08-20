
Class BuscadorDeMapeos(Of ClaseOrigen, ClaseDestino)

    Private elMapeador As MapeadorDePropiedades(Of ClaseOrigen, ClaseDestino)
    Private laPropiedadesEnElOrigen As IEnumerable(Of Propiedad)
    Private laPropiedadesEnElDestino As IEnumerable(Of Propiedad)

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
        laPropiedadesEnElDestino = elBuscador.EncuentreLasPropiedadesEscribibles()
    End Sub

    Private Sub EncuentreLasPropiedadesEnElOrigen()
        If HayPropiedadesEnElDestino() Then
            Dim elTipo As Type = GetType(ClaseOrigen)
            Dim elBuscador = New BuscadorDePropiedadesLegibles(elTipo)
            laPropiedadesEnElOrigen = elBuscador.EncuentreLasPropiedadesLegibles()
        End If
    End Sub

    Private Sub RegistreLosEquivalentesDelDestinoEnElOrigen()
        For Each laPropiedadEnElDestino In laPropiedadesEnElDestino
            RegistreSiSeEncuentraEnElOrigen(laPropiedadEnElDestino)
        Next
    End Sub

    Private Sub RegistreSiSeEncuentraEnElOrigen(laPropiedadEnElDestino As Propiedad)
        For Each unaPropiedadEnElOrigen In laPropiedadesEnElOrigen
            If unaPropiedadEnElOrigen.EsIgualQue(laPropiedadEnElDestino) Then
                elMapeador.RegistreUnNuevoMapeo(unaPropiedadEnElOrigen,
                                                laPropiedadEnElDestino)
                Exit For
            End If
        Next
    End Sub

    Private Function HayPropiedadesEnElDestino() As Boolean
        Return laPropiedadesEnElDestino.Count > 0
    End Function

End Class
