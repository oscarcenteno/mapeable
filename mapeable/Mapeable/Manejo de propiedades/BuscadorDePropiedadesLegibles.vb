Namespace ManejoDePropiedades
    Public Class BuscadorDePropiedadesLegibles
        Private elTipo As Type
        Private lasPropiedades As IEnumerable(Of Propiedad)
        Private lasPropiedadesLegibles As IEnumerable(Of Propiedad)

        Public Sub New(elTipo As Type)
            Me.elTipo = elTipo
        End Sub

        Public Function EncuentreLasPropiedadesLegibles() As IEnumerable(Of Propiedad)
            ListeLasPropiedades()
            EncuentreLasLegibles()

            Return lasPropiedadesLegibles
        End Function

        Private Sub ListeLasPropiedades()
            Dim elBuscador As New BuscadorDePropiedadesPublicas(elTipo)
            lasPropiedades = elBuscador.EncuentreLasPropiedadesPublicas()
        End Sub

        Private Sub EncuentreLasLegibles()
            lasPropiedadesLegibles = lasPropiedades.Where(Function(c) c.SePuedeLeer)
        End Sub
    End Class
End Namespace