Namespace ManejoDePropiedades
    Public Class Propiedad
        Public Property Nombre() As String
        Public Property Tipo() As Type
        Public Property SePuedeEscribir() As Boolean
        Public Property SePuedeLeer() As Boolean
        Public Property TipoDeLaClase() As Type

        Public Function EsIgualQue(otra As Propiedad) As Boolean
            Dim sonIguales As Boolean = False

            If Nombre.Equals(otra.Nombre) And Tipo.Equals(otra.Tipo) Then
                sonIguales = True
            End If

            Return sonIguales
        End Function
    End Class
End Namespace