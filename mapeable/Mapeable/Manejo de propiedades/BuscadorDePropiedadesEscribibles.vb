Namespace ManejoDePropiedades
    Public Class BuscadorDePropiedadesEscribibles
        Private elTipo As Type
        Private lasPropiedades As IEnumerable(Of Propiedad)
        Private lasPropiedadesLegibles As IEnumerable(Of Propiedad)

        Public Sub New(elTipo As Type)
            Me.elTipo = elTipo
        End Sub

        Public Function EncuentreLasPropiedadesEscribibles() As IEnumerable(Of Propiedad)
            ListeLasPropiedadesPublicas()
            EncuentreLasEscribibles()

            Return lasPropiedadesLegibles
        End Function

        Private Sub ListeLasPropiedadesPublicas()
            Dim elBuscador As New BuscadorDePropiedadesPublicas(elTipo)
            lasPropiedades = elBuscador.EncuentreLasPropiedadesPublicas()
        End Sub

        Private Sub EncuentreLasEscribibles()
            lasPropiedadesLegibles = lasPropiedades.Where(Function(c) c.SePuedeEscribir)
        End Sub
    End Class
End Namespace