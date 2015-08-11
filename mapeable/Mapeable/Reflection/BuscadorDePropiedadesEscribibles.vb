Imports System.Reflection

Public Class BuscadorDePropiedadesEscribibles

    Private elTipo As Type
    Public Sub New(elTipo As Type)
        Me.elTipo = elTipo
    End Sub

    Private lasPropiedadesLegibles As IEnumerable(Of Propiedad)
    Public Function EncuentreLasPropiedadesEscribibles() As IEnumerable(Of Propiedad)
        ListeLasPropiedades()
        EncuentreLasEscribibles()

        Return lasPropiedadesLegibles
    End Function

    Dim lasPropiedades As IEnumerable(Of Propiedad)
    Private Sub ListeLasPropiedades()
        Dim elBuscador As New BuscadorDePropiedadesPublicas(elTipo)
        lasPropiedades = elBuscador.EncuentreLasPropiedadesPublicas()
    End Sub

    Private Sub EncuentreLasEscribibles()
        lasPropiedadesLegibles = lasPropiedades.Where(Function(c) c.SePuedeLeer)
    End Sub

End Class
