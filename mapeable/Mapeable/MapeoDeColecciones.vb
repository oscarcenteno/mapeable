Public Class MapeoDeColecciones(Of ClaseOrigen, ClaseDestino As New)
    Private elMapeador As Mapeo(Of ClaseOrigen, ClaseDestino)

    Public Sub New()
        elMapeador = New Mapeo(Of ClaseOrigen, ClaseDestino)
    End Sub

    Public Sub New(elMapeadorPersonalizado As Mapeo(Of ClaseOrigen, ClaseDestino))
        elMapeador = elMapeadorPersonalizado
    End Sub

    Public Function Mapee(laListaOrigen As IEnumerable(Of ClaseOrigen)) As List(Of ClaseDestino)
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