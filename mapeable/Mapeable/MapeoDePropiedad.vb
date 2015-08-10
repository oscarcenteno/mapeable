Imports System.Linq.Expressions

Class MapeoDePropiedad(Of ClaseOrigen, ClaseDestino)

    Property Origen As Propiedad
    Property Destino As Propiedad

    Friend Sub MapeaA(Of TProperty)(expresion As Expression(Of Func(Of ClaseDestino, TProperty)))
        Throw New NotImplementedException
    End Sub

End Class
