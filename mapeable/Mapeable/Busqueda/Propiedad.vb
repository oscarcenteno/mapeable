Public Class Propiedad

    Public Property Nombre As String
    Public Property Tipo As String

    Public Function EsIgualQue(otra As Propiedad) As Boolean
        Dim sonIguales As Boolean

        If Nombre.Equals(otra.Nombre) And Tipo.Equals(otra.Tipo) Then
            sonIguales = True
        End If

        Return sonIguales
    End Function

End Class
