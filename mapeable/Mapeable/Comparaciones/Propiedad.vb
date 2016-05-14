Namespace Comparaciones
    Public Class Propiedad
        Property Nombre As String
        Property Tipo As Type
        Property SePuedeEscribir As Boolean
        Property SePuedeLeer As Boolean
        Property TipoDeLaClase As Type

        Public Function EsIgualQue(otra As Propiedad) As Boolean
            Dim sonIguales As Boolean

            If Nombre.Equals(otra.Nombre) And Tipo.Equals(otra.Tipo) Then
                sonIguales = True
            End If

            Return sonIguales
        End Function

    End Class
End Namespace