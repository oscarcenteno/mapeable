Class MapeadorDePropiedades(Of ClaseOrigen, ClaseDestino)

    Private mapeosPorAplicar As IList(Of MapeoDePropiedad(Of ClaseOrigen, ClaseDestino))
    Private elobjetoOrigen As ClaseOrigen

    Sub New()
        mapeosPorAplicar = New List(Of MapeoDePropiedad(Of ClaseOrigen, ClaseDestino))
    End Sub

    Dim elObjetoDestino As ClaseDestino
    Function Mapee(elobjetoOrigen As ClaseOrigen) As ClaseDestino
        Me.elobjetoOrigen = elobjetoOrigen

        CreeElObjetoDestino()
        MapeeCadaPropiedadAlDestino()

        Return elObjetoDestino
    End Function

    Sub RegistreUnNuevoMapeo(unaPropiedadEnElOrigen As Propiedad,
                             laPropiedadEnElDestino As Propiedad)
        Dim elNuevoMapeo As New MapeoDePropiedad(Of ClaseOrigen, ClaseDestino)
        elNuevoMapeo.Origen = unaPropiedadEnElOrigen
        elNuevoMapeo.Destino = laPropiedadEnElDestino
        mapeosPorAplicar.Add(elNuevoMapeo)
    End Sub

    Private Sub CreeElObjetoDestino()
        elObjetoDestino = Activator.CreateInstance(Of ClaseDestino)()
    End Sub

    Private Sub MapeeCadaPropiedadAlDestino()
        Dim elAplicador As New AplicadorDeMapeo(Of ClaseOrigen, ClaseDestino) _
            (elobjetoOrigen, elObjetoDestino)

        For Each mapeo In mapeosPorAplicar
            elAplicador.ApliqueElMapeo(mapeo)
        Next
    End Sub

End Class
