Imports System.Linq.Expressions

Namespace Mapeos
    Public Class MapeoPersonalizado
        Property LaExpresionOrigen As Func(Of Object, Object)
        Property LaPropiedadDestino As String

        Public Sub New(elOrigen As Func(Of Object, Object))
            LaExpresionOrigen = elOrigen
        End Sub

        Public Shared Function Cree(Of ClaseOrigen, TipoDeLaPropiedad) _
            (laExpresion As Expression(Of Func(Of ClaseOrigen, TipoDeLaPropiedad))) _
            As MapeoPersonalizado

            Dim laExpresionCompilada As Func(Of ClaseOrigen, TipoDeLaPropiedad)
            laExpresionCompilada = laExpresion.Compile()

            Return New MapeoPersonalizado(laExpresionCompilada.TransformadaANoGenerica)
        End Function
    End Class
End Namespace