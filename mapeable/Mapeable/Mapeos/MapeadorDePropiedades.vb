Imports Mapeable.ManejoDePropiedades

Namespace Mapeos
    Class MapeadorDePropiedades(Of ClaseOrigen, ClaseDestino)

        Private losMapeos As IList(Of MapeoDePropiedad(Of ClaseOrigen, ClaseDestino))
        Private losMapeosPersonalizados As IList(Of MapeoPersonalizado)
        Private elObjetoOrigen As ClaseOrigen
        Private elObjetoDestino As ClaseDestino

        Sub New()
            losMapeos = New List(Of MapeoDePropiedad(Of ClaseOrigen, ClaseDestino))
            losMapeosPersonalizados = New List(Of MapeoPersonalizado)
        End Sub

        Sub RegistreUnNuevoMapeo(unaPropiedadEnElOrigen As Propiedad,
                                 laPropiedadEnElDestino As Propiedad)
            Dim elNuevoMapeo As New MapeoDePropiedad(Of ClaseOrigen, ClaseDestino)
            elNuevoMapeo.Origen = unaPropiedadEnElOrigen
            elNuevoMapeo.Destino = laPropiedadEnElDestino
            losMapeos.Add(elNuevoMapeo)
        End Sub

        Sub RegistreUnMapeoPersonalizado(elMapeo As MapeoPersonalizado)
            losMapeosPersonalizados.Add(elMapeo)
        End Sub

        Function Mapee(elObjetoOrigen As ClaseOrigen) As ClaseDestino
            Me.elObjetoOrigen = elObjetoOrigen

            CreeElObjetoDestino()
            MapeeCadaPropiedad()
            MapeeCadaPropiedadPersonalizada()

            Return elObjetoDestino
        End Function

        Private Sub CreeElObjetoDestino()
            elObjetoDestino = Activator.CreateInstance(Of ClaseDestino)()
        End Sub

        Private Sub MapeeCadaPropiedad()
            Dim elMapeadorPorPropiedad As New AsignadorDePropiedades(elObjetoOrigen,
                                                                     elObjetoDestino)
            For Each mapeo In losMapeos
                elMapeadorPorPropiedad.MapeeDelOrigenAlDestino(mapeo.Origen.Nombre,
                                                               mapeo.Destino.Nombre)
            Next
        End Sub

        Private Sub MapeeCadaPropiedadPersonalizada()
            For Each elMapeo In losMapeosPersonalizados
                Dim c As New ContextoDeUnaPropiedad(elObjetoOrigen, elMapeo)
                c.AsigneA(elObjetoDestino)
            Next
        End Sub
    End Class
End Namespace