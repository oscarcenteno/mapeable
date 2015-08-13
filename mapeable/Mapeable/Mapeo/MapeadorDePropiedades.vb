Friend Class MapeadorDePropiedades(Of ClaseOrigen, ClaseDestino)

    Private losMapeos As IList(Of MapeoDePropiedad(Of ClaseOrigen, ClaseDestino))
    Private losMapeosPersonalizados As IList(Of MapeoPersonalizado)
    Private elobjetoOrigen As ClaseOrigen

    Sub New()
        losMapeos = New List(Of MapeoDePropiedad(Of ClaseOrigen, ClaseDestino))
        losMapeosPersonalizados = New List(Of MapeoPersonalizado)
    End Sub

    Dim elObjetoDestino As ClaseDestino
    Function Mapee(eOobjetoOrigen As ClaseOrigen) As ClaseDestino
        Me.elobjetoOrigen = eOobjetoOrigen

        CreeElObjetoDestino()
        MapeeCadaPropiedad()
        MapeeCadaPropiedadPersonalizada()

        Return elObjetoDestino
    End Function

    Sub RegistreUnNuevoMapeo(unaPropiedadEnElOrigen As Propiedad,
                             laPropiedadEnElDestino As Propiedad)
        Dim elNuevoMapeo As New MapeoDePropiedad(Of ClaseOrigen, ClaseDestino)
        elNuevoMapeo.Origen = unaPropiedadEnElOrigen
        elNuevoMapeo.Destino = laPropiedadEnElDestino
        losMapeos.Add(elNuevoMapeo)
    End Sub

    Private Sub CreeElObjetoDestino()
        elObjetoDestino = Activator.CreateInstance(Of ClaseDestino)()
    End Sub

    Private Sub MapeeCadaPropiedad()
        Dim elMapeadorPorPropiedad As New AsignadorDePropiedades(elobjetoOrigen,
                                                                 elObjetoDestino)
        For Each mapeo In losMapeos
            elMapeadorPorPropiedad.MapeeDelOrigenAlDestino(mapeo.Origen.Nombre,
                                                           mapeo.Destino.Nombre)
        Next
    End Sub

    Sub RegistreUnMapeoPersonalizado(elMapeo As MapeoPersonalizado)
        losMapeosPersonalizados.Add(elMapeo)
    End Sub

    Private Sub MapeeCadaPropiedadPersonalizada()
        For Each elMapeo In losMapeosPersonalizados
            Dim c As New ContextoDeUnaPropiedad(elobjetoOrigen, elMapeo)
            c.AsigneA(elObjetoDestino)
        Next
    End Sub

End Class
