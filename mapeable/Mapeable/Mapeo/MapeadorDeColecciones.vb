Public Class MapeadorDeColecciones(Of ClaseOrigen, ClaseDestino)

    Private elMapeador As Mapeador(Of ClaseOrigen, ClaseDestino)

    Public Sub New()
        elMapeador = New Mapeador(Of ClaseOrigen, ClaseDestino)
    End Sub

    Public Sub New(unMapeador As Mapeador(Of ClaseOrigen, ClaseDestino))
        elMapeador = unMapeador
    End Sub

    Public Function MapeeLaColeccion(laListaOrigen As IEnumerable(Of ClaseOrigen)) _
        As IEnumerable(Of ClaseDestino)

        Dim elResultadoDelMapeo As New List(Of ClaseDestino)

        If laListaOrigen IsNot Nothing Then
            For Each objeto In laListaOrigen
                Dim elobjetoDestino As ClaseDestino
                elobjetoDestino = elMapeador.Mapee(objeto)
                elResultadoDelMapeo.Add(elobjetoDestino)
            Next
        End If

        Return elResultadoDelMapeo
    End Function

End Class