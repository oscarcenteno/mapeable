Public Class MapeadorDeColecciones(Of ClaseOrigen, ClaseDestino)

    Private elMapeador As MapeadorBase(Of ClaseOrigen, ClaseDestino)
    Public Sub New()
        elMapeador = New MapeadorBase(Of ClaseOrigen, ClaseDestino)
    End Sub

    Public Sub New(unMapeador As MapeadorBase(Of ClaseOrigen, ClaseDestino))
        elMapeador = unMapeador
    End Sub

    Public Function MapeeLaColeccion(listaDeObjetosOrigen As IEnumerable(Of ClaseOrigen)) _
        As IEnumerable(Of ClaseDestino)

        Dim elResultadoDelMapeo As New List(Of ClaseDestino)

        If listaDeObjetosOrigen IsNot Nothing Then
            For Each objeto In listaDeObjetosOrigen
                Dim elobjetoDestino As ClaseDestino
                elobjetoDestino = elMapeador.Mapee(objeto)
                elResultadoDelMapeo.Add(elobjetoDestino)
            Next
        End If

        Return elResultadoDelMapeo
    End Function

End Class