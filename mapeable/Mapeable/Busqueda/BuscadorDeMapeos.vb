
Class BuscadorDeMapeos(Of ClaseOrigen, ClaseDestino)

    Private elMapeador As MapeadorDePropiedades(Of ClaseOrigen, ClaseDestino)
    Dim propiedadesEnElOrigen As IEnumerable(Of Propiedad)
    Dim propiedadesEnElDestino As IEnumerable(Of Propiedad)

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
        propiedadesEnElDestino = elBuscador.EncuentreLasPropiedadesEscribibles()
    End Sub

    Private Sub EncuentreLasPropiedadesEnElOrigen()
        If HayPropiedadesEnElDestino Then
            Dim elTipo As Type = GetType(ClaseOrigen)
            Dim elBuscador = New BuscadorDePropiedadesLegibles(elTipo)
            propiedadesEnElOrigen = elBuscador.EncuentreLasPropiedadesLegibles()
        End If
    End Sub

    Private Sub RegistreLosEquivalentesDelDestinoEnElOrigen()
        For Each laPropiedadEnElDestino In propiedadesEnElDestino
            RegistreSiSeEncuentraEnElOrigen(laPropiedadEnElDestino)
        Next
    End Sub

    Private Sub RegistreSiSeEncuentraEnElOrigen(laPropiedadEnElDestino As Propiedad)
        For Each unaPropiedadEnElOrigen In propiedadesEnElOrigen
            If unaPropiedadEnElOrigen.EsIgualQue(laPropiedadEnElDestino) Then
                elMapeador.RegistreUnNuevoMapeo(unaPropiedadEnElOrigen,
                                                laPropiedadEnElDestino)
                Exit For
            End If
        Next
    End Sub

    Private Function HayPropiedadesEnElDestino() As Boolean
        Return propiedadesEnElDestino.Count > 0
    End Function

End Class
